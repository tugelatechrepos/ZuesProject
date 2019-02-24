using AccountBalanceManager.Contracts;
using DebtCollectionAccess;
using DebtCollectionAccess.Client;
using DebtCollectionAccess.Contracts;
using Newtonsoft.Json;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountBalanceManagerService.Processor
{
    public interface IGenerateInvoiceProcessor
    {
        GenerateInvoiceProcessorResponse GenerateInvoice();
    }

    public class GenerateInvoiceProcessorResponse
    {
        public int? InvoiceId { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }

  
    public class GenerateInvoiceProcessor : IGenerateInvoiceProcessor
    {
        #region Declarations

        private GenerateInvoiceProcessorResponse _Response;
        private ICollection<Period> _PeriodList;
        private Period _CurrentPeriod;
        private InvoiceDetail _CurrentPeriodLatestInvoiceDetail;
        private InvoiceDetail _InvoiceDetail;
        private List<InvoiceLineItem> _InvoiceLineItemList;
        private List<InvoiceServiceView> _InvoiceServiceViewList;
        private List<DebtCollectionAccess.PaymentHistory> _MarkPaymentHistoryList;
        private ICollection<ServiceType> _ServiceTyeList;

       
       public IDebtCollectionAccessProxy DebtCollectionAccessProxy { get; set; }

        #endregion Declarations

        public GenerateInvoiceProcessorResponse GenerateInvoice()
        {
            _Response = new GenerateInvoiceProcessorResponse { ValidationResults = new ValidationResults() };

            execute();

            return _Response;
        }

        private void execute()
        {
            assignPeriodList();
            assignCurrentPeriod();
            assignServiceTypeList();
            assignLatestInvoiceDetailForCurrentPeriod();
            processInvoiceItemList();
            persistInvoice();
            persistPaymentHistoryList();
        }

        private void assignPeriodList()
        {
            var response = DebtCollectionAccessProxy.GetPeriodList(new GetPeriodListRequest());

            _PeriodList = response.PeriodList;
        }

        private void assignCurrentPeriod()
        {
            if (_PeriodList == null || !_PeriodList.Any()) return;

            var currentMonth = DateTime.Now.Date.Month;
            var currentYear = DateTime.Now.Date.Year;

            _CurrentPeriod = _PeriodList.FirstOrDefault(x => x.FromDate.Month == currentMonth && x.FromDate.Year == currentYear);
        }

        private void assignServiceTypeList()
        {
            var response = DebtCollectionAccessProxy.GetTypeTableList(new GetTypeTableListRequest
            {
                IncludeServiceTypeList = true
            });

            _ServiceTyeList = response.ServiceTypeList;
        }

        private void assignLatestInvoiceDetailForCurrentPeriod()
        {
            var invoiceListResponse = DebtCollectionAccessProxy.GetInvoiceList(new GetInvoiceListRequest { PeriodIdList = new List<int> { _CurrentPeriod.Id } });

            var invoiceDetailListString = invoiceListResponse.InvoiceList.Select(x => x.Detail);
            var invoiceDetailList = new List<InvoiceDetail>();

            foreach(var invoice in invoiceListResponse.InvoiceList)
            {
                var invoiceDetail = Newtonsoft.Json.JsonConvert.DeserializeObject<InvoiceDetail>(invoice.Detail);
                invoiceDetail.InvoiceId = invoice.Id;
                invoiceDetail.GeneratedOn = invoice.GeneratedOn;
                invoiceDetail.PeriodId = invoice.PeriodId;
                invoiceDetailList.Add(invoiceDetail);
            }            

            if (invoiceDetailList == null || !invoiceDetailList.Any()) return;

            _CurrentPeriodLatestInvoiceDetail = invoiceDetailList.OrderByDescending(x => x.InvoiceId).FirstOrDefault();
        }

        private void processInvoiceItemList()
        {
            if (_PeriodList == null || !_PeriodList.Any()) return;

            var periodList = _PeriodList.Where(x => x.FromDate <= _CurrentPeriod.FromDate).OrderByDescending(x => x.FromDate);
            _InvoiceLineItemList = new List<InvoiceLineItem>();
            _InvoiceServiceViewList = new List<InvoiceServiceView>();
            _MarkPaymentHistoryList = new List<DebtCollectionAccess.PaymentHistory>();

            _InvoiceDetail = new InvoiceDetail
            {
                InvoiceLineItemList = _InvoiceLineItemList,
                InvoiceServiceViewList = _InvoiceServiceViewList,
                ExpenseList = _CurrentPeriodLatestInvoiceDetail?.ExpenseList
            };

            foreach (var period in periodList)
            {
                var paymentHistoryList = getPaymentHistoryList(period);

                if (period != _CurrentPeriod)
                {
                    redactPaymentHistoryList(paymentHistoryList);
                }

                _MarkPaymentHistoryList.AddRange(paymentHistoryList);
                var totalOpeningBalance = getTotalOpeningBalance(period.Id);
                assignInvoiceLineItemList(paymentHistoryList, period, totalOpeningBalance);
                assignInvoiceServiceViewList(paymentHistoryList, period, totalOpeningBalance);
            }
        }

        private void assignInvoiceLineItemList(ICollection<DebtCollectionAccess.PaymentHistory> PaymentHistoryList, Period Period, decimal TotalOpeningBalance)
        {
            var decription = Period.Name;
            var totalPaid = PaymentHistoryList.Sum(x => x.Amount);
            var totalOpeningBalance = getTotalOpeningBalance(Period.Id);
            var yield = (totalPaid / totalOpeningBalance) * 100;
            var commissionPercentage = getCommissionPercentage(yield.Value);
            var totalAmount = totalPaid * (commissionPercentage / 100);
            var accountIdList = PaymentHistoryList.Select(x => x.AccountId).Distinct().ToList();
            var totalNumberOfAccounts = accountIdList.Count();

            var invoiceLineItem = new InvoiceLineItem
            {
                AccountIdList = accountIdList,
                Description = decription,
                PeriodId = Period.Id,
                TotalPaid = totalPaid.Value,
                TotalOpeningBalance = totalOpeningBalance,
                NumberOfAccounts = totalNumberOfAccounts,
                Yield = yield.Value,
                CommissionPercentage = commissionPercentage,
                Amount = totalAmount.Value
            };

            _InvoiceLineItemList.Add(invoiceLineItem);
        }

        private void assignInvoiceServiceViewList(ICollection<DebtCollectionAccess.PaymentHistory> PaymentHistoryList, Period Period, decimal TotalOpeningBalance)
        {
            var invoiceServiceView = new InvoiceServiceView();

            var serviceDetailList = PaymentHistoryList.GroupBy(x => x.ServiceId).Select(y => new ServiceDetail
            {
                ServiceId = y.Key,
                ServiceName = _ServiceTyeList.FirstOrDefault(serviceType => serviceType.Id == y.Key).Name,
                AccountIdList = y.Select(acc => acc.AccountId).Distinct().ToList(),
                NumberOfAccounts = y.Select(acc => acc.AccountId).Distinct().Count(),
                Amount = y.Sum(c => c.Amount.Value)
            }).ToList();

            var totalPaid = serviceDetailList.Sum(x => x.Amount);
            var yield = (totalPaid / TotalOpeningBalance) * 100;
            var commissionPercentage = getCommissionPercentage(yield);
            var totalAmount = totalPaid * (commissionPercentage / 100);

            invoiceServiceView.PeriodId = Period.Id;
            invoiceServiceView.Description = Period.Name;
            invoiceServiceView.ServiceDetailList = serviceDetailList;
            invoiceServiceView.TotalPaid = totalPaid;
            invoiceServiceView.TotalOpeningBalance = TotalOpeningBalance;
            invoiceServiceView.Yield = yield;
            invoiceServiceView.CommissionPercentage = commissionPercentage;
            invoiceServiceView.Amount = totalAmount;


            _InvoiceServiceViewList.Add(invoiceServiceView);
        }

        private void redactPaymentHistoryList(List<DebtCollectionAccess.PaymentHistory> PaymentHistoryList)
        {
            var accountIdList = PaymentHistoryList.Select(x => x.AccountId).Distinct().ToList();

            var accountInceptionList = getAccountInceptionList(accountIdList);

            if (accountInceptionList == null || !accountInceptionList.Any()) return;

            foreach (var accountId in accountIdList)
            {
                var accountInception = accountInceptionList.FirstOrDefault(x => x.AccountId == accountId);

                if (accountInception == null) continue;

                PaymentHistoryList.RemoveAll(x => x.AccountId == accountId && x.PaymentDate < accountInception.StartDate);
            }
        }

        private ICollection<AccountInception> getAccountInceptionList(ICollection<int> AccountIdList)
        {
            var response = DebtCollectionAccessProxy.GetAccountInceptionList(new GetAccountInceptionListRequest
            {
                AccountIdList = AccountIdList
            });

            return response.AccountInceptionList;
        }

        private decimal getCommissionPercentage(decimal Yield)
        {
            var response = DebtCollectionAccessProxy.GetCommission(new GetCommissionRequest { Yield = Yield });
            return Convert.ToDecimal(response.Commission.CommissionPercentage);
        }

        private decimal getTotalOpeningBalance(int PeriodId)
        {
            var response = DebtCollectionAccessProxy.GetAccountBalanceList(new GetAccountBalanceListRequest { PeriodIdList = new List<int> { PeriodId } });

            var accountBalanceList = response.AccountBalanceList;
            var totalOpeningBalance = accountBalanceList.Sum(x => x.OpeningBalance);
            return totalOpeningBalance;

        }

        private List<DebtCollectionAccess.PaymentHistory> getPaymentHistoryList(Period Period)
        {
            var paymentHistoryList = new List<DebtCollectionAccess.PaymentHistory>();
            var invoiceId = Period == _CurrentPeriod ? (int?)null : _CurrentPeriodLatestInvoiceDetail?.InvoiceId  ?? null ;

            int Skip = 0;
            int Take = 1000;
            do
            {
                var paymentHistoryListResponse = DebtCollectionAccessProxy.GetPaymentHistoryList(new GetPaymentHistoryListRequest
                {
                    FromDate = Period.FromDate,
                    ToDate = Period.ToDate,
                    Skip = Skip,
                    Take = Take,
                    InvoiceId = invoiceId
                });

                if (paymentHistoryListResponse.PaymentHistoryList == null || !paymentHistoryListResponse.PaymentHistoryList.Any()) continue;
                Skip = paymentHistoryListResponse.PaymentHistoryList.Count;
                paymentHistoryList.AddRange(paymentHistoryListResponse.PaymentHistoryList);
            }
            while (Skip == Take);

            return paymentHistoryList.ToList();
        }

        private void persistInvoice()
        {
            var invoice = new Invoice
            {
                PeriodId = _CurrentPeriod.Id,
                Detail = JsonConvert.SerializeObject(_InvoiceDetail),
                GeneratedOn = DateTime.Now.Date,
            };

            var response = DebtCollectionAccessProxy.PersistInvoice(new PersistInvoiceRequest { Invoice = invoice });

            _Response.InvoiceId = response.InvoiceId;
        }

        private void persistPaymentHistoryList()
        {
            if (!_Response.InvoiceId.HasValue || _Response.InvoiceId.Value == 0) return;
            if (_MarkPaymentHistoryList == null || !_MarkPaymentHistoryList.Any()) return;

            _MarkPaymentHistoryList.ForEach(x => x.InvoiceId = _Response.InvoiceId.Value);

            int Skip = 0;
            int Take = 1000;
            do
            {
                var listToPersist = _MarkPaymentHistoryList.Skip(Skip).Take(Take).ToList();
                Skip = listToPersist.Count();
                var response = DebtCollectionAccessProxy.PersistPaymentHistoryList(new PersistPaymentHistoryListRequest
                {
                    PaymentHistoryList = listToPersist
                });
            }
            while (Skip == Take);
        }
    }
}