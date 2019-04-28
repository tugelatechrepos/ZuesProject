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
        GenerateInvoiceProcessorResponse GenerateInvoice(GenerateInvoiceProcessorRequest Request);
    }

    public class GenerateInvoiceProcessorRequest
    {
        public int PeriodId { get; set; }

        public int CompanyId { get; set; }
    }

    public class GenerateInvoiceProcessorResponse
    {
        public int? InvoiceId { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }

  
    public class GenerateInvoiceProcessor : IGenerateInvoiceProcessor
    {
        #region Declarations

        private GenerateInvoiceProcessorRequest _Request;
        private GenerateInvoiceProcessorResponse _Response;
        private InvoiceDetail _InvoiceDetail;
        private List<InvoiceLineItem> _InvoiceLineItemList;
        private List<InvoiceServiceView> _InvoiceServiceViewList;
        private ICollection<ServiceType> _ServiceTypeList;
        private Period _Period;
        
        public IDebtCollectionAccessProxy DebtCollectionAccessProxy { get; set; }

        #endregion Declarations

        public GenerateInvoiceProcessorResponse GenerateInvoice(GenerateInvoiceProcessorRequest Request)
        {
            _Request = Request;
            _Response = new GenerateInvoiceProcessorResponse { ValidationResults = new ValidationResults() };

            execute();

            return _Response;
        }

        private void execute()
        {
            assignPeriod();
            assignServiceTypeList();
            processInvoice();         
            persistInvoice();            
        }

        private void assignPeriod()
        {
            var periodListResponse = DebtCollectionAccessProxy.GetPeriodList(new DebtCollectionAccess.Contracts.GetPeriodListRequest
            {
                PeriodIdList = new List<int> { _Request.PeriodId }
            });

            _Period = periodListResponse.PeriodList.FirstOrDefault();
        }      

        private void processInvoice()
        {
            _InvoiceLineItemList = new List<InvoiceLineItem>();
            _InvoiceServiceViewList = new List<InvoiceServiceView>();

            var paymentHistoryList = getPaymentHistoryList(_Period);
            var totalOpeningBalance = getTotalOpeningBalance(_Period.Id);

            assignInvoiceLineItemList(paymentHistoryList, _Period, totalOpeningBalance);
            assignInvoiceServiceViewList(paymentHistoryList, _Period, totalOpeningBalance);
        }   

        private void assignServiceTypeList()
        {
            var response = DebtCollectionAccessProxy.GetTypeTableList(new GetTypeTableListRequest
            {
                IncludeServiceTypeList = true
            });

            _ServiceTypeList = response.ServiceTypeList;
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
                ServiceName = _ServiceTypeList.FirstOrDefault(serviceType => serviceType.Id == y.Key).Name,
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

        private decimal getCommissionPercentage(decimal Yield)
        {
            var response = DebtCollectionAccessProxy.GetCommission(new GetCommissionRequest { Yield = Yield });
            return Convert.ToDecimal(response.Commission.CommissionPercentage);
        }

        private decimal getTotalOpeningBalance(int PeriodId)
        {
            var response = DebtCollectionAccessProxy.GetAccountBalanceList(new GetAccountBalanceListRequest { PeriodIdList = new List<int> { PeriodId } ,CompanyId = _Request.CompanyId});

            var accountBalanceList = response.AccountBalanceList;
            var totalOpeningBalance = accountBalanceList.Sum(x => x.OpeningBalance);
            return totalOpeningBalance;
        }

        private List<DebtCollectionAccess.PaymentHistory> getPaymentHistoryList(Period Period)
        {
            var paymentHistoryList = new List<DebtCollectionAccess.PaymentHistory>();           

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
                    CompanyId = _Request.CompanyId,
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
            _InvoiceDetail = new InvoiceDetail
            {
                GeneratedOn = DateTime.Now.Date,
                InvoiceLineItemList = _InvoiceLineItemList,
                InvoiceServiceViewList = _InvoiceServiceViewList,
                PeriodId = _Period.Id
            };

            var invoice = new Invoice
            {
                PeriodId = _Period.Id,
                Detail = JsonConvert.SerializeObject(_InvoiceDetail),
                GeneratedOn = DateTime.Now.Date,
                CompanyId = _Request.CompanyId,
            };

            var response = DebtCollectionAccessProxy.PersistInvoice(new PersistInvoiceRequest { Invoice = invoice });

            _Response.InvoiceId = response.InvoiceId;
        }       
    }
}