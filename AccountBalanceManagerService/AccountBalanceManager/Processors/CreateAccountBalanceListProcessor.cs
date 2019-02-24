using DebtCollectionAccess;
using DebtCollectionAccess.Client;
using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountBalanceManagerService.Processor
{
    public interface ICreateAccountBalanceListProcessor
    {
        CreateAccountBalanceListResponse CreateAccountBalanceList(CreateAccountBalanceListRequest Request);
    }

    public class CreateAccountBalanceListRequest
    {
        public ICollection<PaymentHistory> PaymentHistoryList { get; set; }

        public ICollection<Period> PeriodList { get; set; } 

        public Period CurrentPeriod { get; set; }
    }

    public class CreateAccountBalanceListResponse
    {
        public ICollection<AccountBalance> AccountBalanceList { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }

   
    public class CreateAccountBalanceListProcessor : ICreateAccountBalanceListProcessor
    {
        #region Declarations

        private CreateAccountBalanceListRequest _Request;
        private CreateAccountBalanceListResponse _Response;
        private ICollection<Period> _PeriodList;
        private ICollection<PaymentHistory> _PaymentHistoryList;
        private Period _CurrentPeriod;
        private Period _NextPeriod;
        private Period _PreviousPeriod;
        private List<AccountBalance> _AccountBalanceList;
        private ICollection<AccountOpeningBalance> _CurrentPeriodOpeningBalanceList;
        private ICollection<AccountAod> _AccountAODList;
        private ICollection<AccountOwner> _AccountOwnerList;

        public IDebtCollectionAccessProxy DebtCollectionAccessProxy { get; set; }

        #endregion Declarations

        public CreateAccountBalanceListResponse CreateAccountBalanceList(CreateAccountBalanceListRequest Request)
        {
            _Request = Request;

            _Response = new CreateAccountBalanceListResponse { ValidationResults = new ValidationResults(), AccountBalanceList = new List<AccountBalance>() };

            _PeriodList = _Request.PeriodList;
            _PaymentHistoryList = _Request.PaymentHistoryList;
            _CurrentPeriod = _Request.CurrentPeriod;
            _AccountBalanceList = new List<AccountBalance>();

            execute();

            return _Response;
        }

        private void execute()
        {
            assignNextPeriod();
            assignPreviousPeriod();
            assignCurrentPeriodOpeningBalanceList();
            assignAccountAodList();
            assignAccountOwnerList();
            assignAccountBalanceList();
            assignNextPeriodAccountBalanceList();
            persistAccountBalanceList();
        }

        private void assignNextPeriod()
        {
            if (_CurrentPeriod == null) return;

            _NextPeriod = _PeriodList.Where(x => x.FromDate > _CurrentPeriod.FromDate).OrderBy(x => x.FromDate).FirstOrDefault();
        }

        private void assignPreviousPeriod()
        {
            if (_CurrentPeriod == null) return;

            _PreviousPeriod = _PeriodList.Where(x => x.FromDate < _CurrentPeriod.FromDate).OrderBy(x => x.FromDate).FirstOrDefault();
        }

        private void assignCurrentPeriodOpeningBalanceList()
        {
            if (_CurrentPeriod == null) return;

            var response = DebtCollectionAccessProxy.GetAccountOpeningBalanceList(new GetAccountOpeningBalanceListRequest
            {
                PeriodId = _CurrentPeriod.Id
            });

            _CurrentPeriodOpeningBalanceList = response.AccountOpeningBalanceList;
        }   

        private void assignAccountAodList()
        {
            var accountIdList = _PaymentHistoryList.Select(x => x.AccountId).Distinct().ToList();
             var response = DebtCollectionAccessProxy.GetAccountAODList(new GetAccountAODListRequest { AccountIdList = accountIdList });
            _AccountAODList =  response.AccountAODList;
        }

        private void assignAccountOwnerList()
        {
            var accountIdList = _PaymentHistoryList.Select(x => x.AccountId).Distinct().ToList();
            var response = DebtCollectionAccessProxy.GetAccountOwnerList(new GetAccountOwnerListRequest { AccountIdList = accountIdList });
            _AccountOwnerList =  response.AccountOwnerList;
        }

        private void assignAccountBalanceList()
        {
            var periodList = _PeriodList.Where(x => x.FromDate <= _CurrentPeriod.FromDate).OrderByDescending(x => x.FromDate).ToList();

            foreach (var period in periodList)
            {
                var paymentHistoryList = _PaymentHistoryList.Where(x => x.PaymentDate >= period.FromDate && x.PaymentDate <= period.ToDate);
                var accountGroupList = paymentHistoryList.GroupBy(x => x.AccountId).Select(y => new
                {
                    AccountId = y.Key,
                    TotalPaid = y.Sum(z => z.Amount)
                }).ToList();

                var accountIdList = accountGroupList.Select(x => x.AccountId).Distinct().ToList();
                var periodIdList = periodList.Select(x => x.Id).Distinct().ToList();               

                foreach(var accountGroup in accountGroupList)
                {
                    var accountOpeningBalance = getOpeningBalance(period, accountGroup.AccountId);
                    var totalPaid = accountGroup.TotalPaid;

                    var openingBalance = period == _CurrentPeriod ? accountOpeningBalance : (accountOpeningBalance + totalPaid);
                    var remainingBalance = period == _CurrentPeriod ? (totalPaid >= accountOpeningBalance) ? 0 : (accountOpeningBalance - totalPaid) : accountOpeningBalance;
                    var aodAmount = _AccountAODList.FirstOrDefault(x => x.AccountId == accountGroup.AccountId)?.Amount;
                    var accountOwner = _AccountOwnerList.FirstOrDefault(x => x.AccountId == accountGroup.AccountId);

                    var accountbalance = new AccountBalance();
                    accountbalance.AccountId = accountGroup.AccountId;
                    accountbalance.PeriodId = period.Id;
                    accountbalance.Paid = totalPaid;
                    accountbalance.OpeningBalance = openingBalance.Value;
                    accountbalance.RemainingBalance = remainingBalance;
                    accountbalance.PromisedAmount = aodAmount;
                    accountbalance.IsPartialPayment = totalPaid > 0 ? totalPaid < aodAmount : (bool?)null;
                    accountbalance.IsPaymentMissed = totalPaid == 0;
                    accountbalance.OwnerId = accountOwner?.OwnerId;

                    _AccountBalanceList.Add(accountbalance);
                }            
            }
        }        

        private void assignNextPeriodAccountBalanceList()
        {
            if (_NextPeriod == null) return;
            if (_AccountBalanceList == null || !_AccountBalanceList.Any()) return;

            var currentPeriodAccountBalanceList = _AccountBalanceList.Where(x => x.PeriodId == _CurrentPeriod.Id).ToList();

            var accountBalanceList = currentPeriodAccountBalanceList.Select(x => new AccountBalance
            {
                Id = x.Id,
                OpeningBalance = x.RemainingBalance.Value,
                RemainingBalance = x.RemainingBalance,
                AccountId = x.AccountId,
                PeriodId = _NextPeriod.Id,
                OwnerId = _AccountOwnerList?.FirstOrDefault(y=>y.AccountId == x.AccountId)?.OwnerId
            }).ToList();

            _AccountBalanceList.AddRange(accountBalanceList);
        }

        private decimal getOpeningBalance(Period period, int AccountId)
        {
            var periodIndex = _PeriodList.ToList().IndexOf(period);
            var currentPeriodIndex = _PeriodList.ToList().IndexOf(_CurrentPeriod);

            decimal openingBalance = 0.0M;

            if (currentPeriodIndex == periodIndex)
            {
                var accountOpeningBalance = _CurrentPeriodOpeningBalanceList.FirstOrDefault(x => x.AccountId == AccountId);
                openingBalance = accountOpeningBalance.OpeningBalance;
                return openingBalance;
            }

            var forwardPeriod = _PeriodList.ToList()[periodIndex - 1];

            var accountBalance = _AccountBalanceList.FirstOrDefault(x => x.PeriodId == forwardPeriod.Id && x.AccountId == AccountId);

            return accountBalance.OpeningBalance;
        }

        private void persistAccountBalanceList()
        {
            if (_AccountBalanceList == null || !_AccountBalanceList.Any()) return;

            int Skip = 0;
            int Take = 1000;
            do
            {
                var listToPersist = _AccountBalanceList.Skip(Skip).Take(Take).ToList();

                var response = DebtCollectionAccessProxy.PersistAccountBalanceList(new PersistAccountBalanceListRequest
                {
                    AccountBalanceList = listToPersist
                });

                Skip = listToPersist.Count();
            }
            while (Skip == Take);
        }
    }
}