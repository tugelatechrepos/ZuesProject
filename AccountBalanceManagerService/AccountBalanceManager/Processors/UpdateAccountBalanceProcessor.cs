using DebtCollectionAccess;
using DebtCollectionAccess.Client;
using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountBalanceManagerService.Processor
{
    public interface IUpdateAccountBalanceProcessor
    {
        UpdateAccountBalanceProcessorResponse UpdateAccountBalanceList(UpdateAccountBalanceProcessorRequest Request);
    }

    public class UpdateAccountBalanceProcessorRequest
    {
        public ICollection<PaymentHistory> PaymentHistoryList { get; set; }

        public ICollection<AccountBalance> CurrentPeriodAccountBalanceList { get; set; }

        public ICollection<Period> PeriodList { get; set; }

        public Period CurrentPeriod { get; set; }

        public ICollection<AccountOpeningBalance> CurrentPeriodOpeningBalanceList { get; set; }
    }

    public class UpdateAccountBalanceProcessorResponse
    {
        public ValidationResults ValidationResults { get; set; }
    }


    public class UpdateAccountBalanceProcessor : IUpdateAccountBalanceProcessor
    {
        #region Declarations

        private UpdateAccountBalanceProcessorRequest _Request;
        private UpdateAccountBalanceProcessorResponse _Response;
        private ICollection<AccountBalance> _CurrentPeriodAccountBalanceList;
        private ICollection<Period> _PeriodList;
        private Period _CurrentPeriod;
        private ICollection<PaymentHistory> _PaymentHistoryList;
        private ICollection<AccountOpeningBalance> _CurrentPeriodOpeningBalanceList;
        private List<AccountBalance> _AccountBalanceList;
        private Period _NextPeriod;
        private ICollection<AccountBalance> _NextPeriodAccountBalanceList;
        private ICollection<AccountBalance> _PreviousPeriodAccountBalanceList;
        private List<int> _AccountIdListToBeDeleted;
        private Period _PreviousPeriod;
        private ICollection<AccountAod> _AccountAODList;
        private ICollection<AccountOwner> _AccountOwnerList;

         public IDebtCollectionAccessProxy DebtCollectionAccessProxy { get; set; }

        #endregion Declarations

        public UpdateAccountBalanceProcessorResponse UpdateAccountBalanceList(UpdateAccountBalanceProcessorRequest Request)
        {
            _Request = Request;
            _Response = new UpdateAccountBalanceProcessorResponse { ValidationResults = new ValidationResults() };

            _CurrentPeriodAccountBalanceList = _Request.CurrentPeriodAccountBalanceList;
            _PeriodList = _Request.PeriodList;
            _CurrentPeriod = _Request.CurrentPeriod;
            _PaymentHistoryList = _Request.PaymentHistoryList;
            _CurrentPeriodOpeningBalanceList = _Request.CurrentPeriodOpeningBalanceList;
            _AccountBalanceList = new List<AccountBalance>();

            execute();

            return _Response;
        }

        private void execute()
        {
            assignNextPeriod();
            assignPreviousPeriod();
            assignNextPeriodAccountBalanceList();
            assignPreviousPeriodAccountBalanceList();
            assignAccountAodList();
            assignAccountOwnerList();
            assignAccountBalanceList();
            updateNextPeriodAccountBalanceList();
            assignNewAccountAccountBalanceList();
            deleteAccountBalanceList();
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

        private void assignNextPeriodAccountBalanceList()
        {
            if (_NextPeriod == null) return;

            var response = DebtCollectionAccessProxy.GetAccountBalanceList(new GetAccountBalanceListRequest
            {
                PeriodIdList = new List<int> { _NextPeriod.Id }
            });

            _NextPeriodAccountBalanceList = response.AccountBalanceList;
        }

        private void assignPreviousPeriodAccountBalanceList()
        {
            if (_PreviousPeriod == null) return;

            var response = DebtCollectionAccessProxy.GetAccountBalanceList(new GetAccountBalanceListRequest
            {
                PeriodIdList = new List<int> { _PreviousPeriod.Id }
            });

            _PreviousPeriodAccountBalanceList = response.AccountBalanceList;
        }

        private void assignAccountAodList()
        {
            var accountIdList = _PaymentHistoryList.Select(x => x.AccountId).Distinct().ToList();
            var response = DebtCollectionAccessProxy.GetAccountAODList(new GetAccountAODListRequest { AccountIdList = accountIdList });
            _AccountAODList = response.AccountAODList;
        }

        private void assignAccountOwnerList()
        {
            var accountIdList = _PaymentHistoryList.Select(x => x.AccountId).Distinct().ToList();
            var response = DebtCollectionAccessProxy.GetAccountOwnerList(new GetAccountOwnerListRequest { AccountIdList = accountIdList });
            _AccountOwnerList = response.AccountOwnerList;
        }

        private void assignAccountBalanceList()
        {
            var paymentHistoryList = _PaymentHistoryList.Where(x => x.PaymentDate >= _CurrentPeriod.FromDate && x.PaymentDate <= _CurrentPeriod.ToDate);
            var paymentHistoryGroupList = paymentHistoryList.GroupBy(x => x.AccountId).Select(y => new
            {
                AccountId = y.Key,
                TotalPaid = y.Sum(c => c.Amount)
            }).ToList();

            foreach (var currentPeriodAccountBalance in _CurrentPeriodAccountBalanceList)
            {
                var accountBalance = new AccountBalance();
                var totalPaid = paymentHistoryGroupList.FirstOrDefault(y => y.AccountId == currentPeriodAccountBalance.AccountId).TotalPaid;
                var promisedAmount = _AccountAODList.FirstOrDefault(x => x.AccountId == currentPeriodAccountBalance.AccountId)?.Amount;

                accountBalance.Id = currentPeriodAccountBalance.Id;
                accountBalance.AccountId = currentPeriodAccountBalance.AccountId;
                accountBalance.OpeningBalance = currentPeriodAccountBalance.OpeningBalance;
                accountBalance.Paid = totalPaid;
                accountBalance.RemainingBalance = (currentPeriodAccountBalance.OpeningBalance - totalPaid);
                accountBalance.PromisedAmount = promisedAmount ?? null;
                accountBalance.IsPartialPayment = promisedAmount == null ? (bool?)null : (totalPaid < promisedAmount);
                accountBalance.IsPaymentMissed = promisedAmount == null ? (bool?)null : totalPaid == 0;
                accountBalance.PeriodId = currentPeriodAccountBalance.PeriodId;
                accountBalance.OwnerId = currentPeriodAccountBalance.OwnerId;

                _AccountBalanceList.Add(accountBalance);
            }
        }

        private void updateNextPeriodAccountBalanceList()
        {
            if (_NextPeriod == null) return;

            var nextPeriodAccountBalanceList = (_NextPeriodAccountBalanceList != null && _NextPeriodAccountBalanceList.Any()) ? _NextPeriodAccountBalanceList
                  : _AccountBalanceList.Where(x => x.PeriodId == _CurrentPeriod.Id).ToList();

            var accountBalanceListForNextPeriod = nextPeriodAccountBalanceList.Select(x => new AccountBalance
            {
                Id = (_NextPeriodAccountBalanceList != null && _NextPeriodAccountBalanceList.Any()) ? x.Id : 0,
                AccountId = x.AccountId,
                OpeningBalance = x.RemainingBalance.Value,
                RemainingBalance = x.RemainingBalance,
                PeriodId = _NextPeriod.Id,
                OwnerId = x.OwnerId
            }).ToList();

            _AccountBalanceList.AddRange(accountBalanceListForNextPeriod);
        }

        private void assignNewAccountAccountBalanceList()
        {
            if (_PreviousPeriodAccountBalanceList == null || !_PreviousPeriodAccountBalanceList.Any()) return;

            var currentPeriodAccountIdList = _AccountBalanceList.Where(x => x.PeriodId == _CurrentPeriod.Id).Select(x => x.AccountId).Distinct().ToList();
            var previousPeriodAccountIdList = _PreviousPeriodAccountBalanceList.Select(x => x.AccountId).Distinct().ToList();

            if (currentPeriodAccountIdList.Count() == previousPeriodAccountIdList.Count()) return;
            if (currentPeriodAccountIdList.Count() < previousPeriodAccountIdList.Count())
            {
                _AccountIdListToBeDeleted = previousPeriodAccountIdList.Except(currentPeriodAccountIdList).ToList();
                return;
            }

            var accountIdList = currentPeriodAccountIdList.Except(previousPeriodAccountIdList).ToList();

            var accountBalanceList = getNewAccountAccountBalanceList(accountIdList);

            _AccountBalanceList.AddRange(accountBalanceList);
        }

        private ICollection<AccountBalance> getNewAccountAccountBalanceList(ICollection<int> AccountIdList)
        {
            var periodList = _PeriodList.Where(x => x.FromDate < _CurrentPeriod.FromDate).OrderByDescending(x => x.FromDate).ToList();

            ICollection<AccountBalance> accountBalanceList = new List<AccountBalance>();

            foreach (var period in periodList)
            {
                var paymentHistoryListForNewAccountIdList = _PaymentHistoryList.Where(x => AccountIdList.Contains(x.AccountId) && (x.PaymentDate >= period.FromDate && x.PaymentDate <= period.ToDate));

                var paymentHistoryGroupList = paymentHistoryListForNewAccountIdList.GroupBy(x => x.AccountId).Select(y => new
                {
                    AccountId = y.Key,
                    TotalPaid = y.Sum(c => c.Amount)
                }).ToList();


                foreach (var paymentHistoryGroup in paymentHistoryGroupList)
                {
                    var totalPaid = paymentHistoryGroup.TotalPaid.Value;
                    var openingBalance = getOpeningBalance(period, paymentHistoryGroup.AccountId);
                    var aodAmount = _AccountAODList.FirstOrDefault(x => x.AccountId == paymentHistoryGroup.AccountId)?.Amount;
                    var accountOwner = _AccountOwnerList.FirstOrDefault(x => x.AccountId == paymentHistoryGroup.AccountId);
                    var accountBalance = new AccountBalance();

                    accountBalance.AccountId = paymentHistoryGroup.AccountId;
                    accountBalance.Paid = totalPaid;
                    accountBalance.PeriodId = period.Id;
                    accountBalance.RemainingBalance = openingBalance;
                    accountBalance.OpeningBalance = openingBalance + totalPaid;
                    accountBalance.PromisedAmount = aodAmount;
                    accountBalance.IsPartialPayment = totalPaid > 0 ? aodAmount < totalPaid : (bool?)null;
                    accountBalance.IsPaymentMissed = totalPaid == 0;
                    accountBalance.OwnerId = accountOwner?.OwnerId;

                    accountBalanceList.Add(accountBalance);
                }
            }

            return accountBalanceList;
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

            var forwardPeriod = _PeriodList.ToList()[periodIndex + 1];

            var accountBalance = _AccountBalanceList.FirstOrDefault(x => x.PeriodId == forwardPeriod.Id && x.AccountId == AccountId);

            return accountBalance.OpeningBalance;
        }

        private void deleteAccountBalanceList()
        {
            if (_AccountIdListToBeDeleted == null || !_AccountIdListToBeDeleted.Any()) return;


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