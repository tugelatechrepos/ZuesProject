using System;
using System.Collections.Generic;
using System.Linq;
using DebtCollectionAccess;
using DebtCollectionAccess.Client;
using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;

namespace AccountBalanceManagerService.Processor
{
    public interface IAccountBalanceCalculationProcessor
    {
        AccountBalanceCalculationProcessorResponse ProcessAccountBalanceList(AccountBalanceCalculationProcessorRequest Request);
    }

    public class AccountBalanceCalculationProcessorRequest
    {
        public int CompanyId { get; set; }
    }

    public class AccountBalanceCalculationProcessorResponse
    {
        public ValidationResults ValidationResults { get; set; }
    }

   
    public class AccountBalanceCalculationProcessor : IAccountBalanceCalculationProcessor
    {

        #region Declarations

        private AccountBalanceCalculationProcessorRequest _Request;
        private AccountBalanceCalculationProcessorResponse _Response;
        private ICollection<Period> _PeriodList;
        private Period _CurrentPeriod;
        private List<PaymentHistory> _PaymentHistoryList;
        private ICollection<AccountBalance> _CurrentPeriodAccountBalanceList;
        private ICollection<AccountOpeningBalance> _CurrentPeriodOpeningBalanceList; 
        
        public IDebtCollectionAccessProxy DebtCollectionAccessProxy { get; set; }
        public ICreateAccountBalanceListProcessor CreateAccountBalanceListProcessor { get; set; }       
        public IUpdateAccountBalanceProcessor UpdateAccountBalanceProcessor { get; set; }

        #endregion Declarations

        public AccountBalanceCalculationProcessorResponse ProcessAccountBalanceList(AccountBalanceCalculationProcessorRequest Request)
        {
            _Request = Request;
            _Response = new AccountBalanceCalculationProcessorResponse { ValidationResults = new ValidationResults() };

            execute();

            return _Response;
        }

        private void execute()
        {
            assignPeriodList();
            assignCurrentPeriod();
            assignPaymentHistoryList();
            assignCurrentPeriodAccountBalanceList();
            assignCurrentPeriodAccountOpeningBalanceList();
            createAccountBalanceList();
            updateAccountBalanceList();
        }

        private void assignPeriodList()
        {
            var response = DebtCollectionAccessProxy.GetPeriodList(new GetPeriodListRequest { CompanyId = _Request.CompanyId });

            _Response.ValidationResults = response.ValidationResults;
            _PeriodList = response.PeriodList;
        }

        private void assignCurrentPeriod()
        {
            if (!_Response.ValidationResults.IsValid) return;
            if (_PeriodList == null || !_PeriodList.Any()) return;

            var currentMonth = DateTime.Now.Date.Month;
            var currentYear = DateTime.Now.Date.Year;

            _CurrentPeriod = _PeriodList.FirstOrDefault(x => x.FromDate.Month == currentMonth && x.FromDate.Year == currentYear);
        }

        private void assignPaymentHistoryList()
        {
            if (!_Response.ValidationResults.IsValid) return;

            _PaymentHistoryList = new List<PaymentHistory>();

            int Skip = 0;
            int Take = 1000;
            do
            {
                var response = DebtCollectionAccessProxy.GetPaymentHistoryList(new GetPaymentHistoryListRequest
                {
                    Skip = Skip,
                    Take = Take,
                    CompanyId = _Request.CompanyId,
                });

                _Response.ValidationResults = response.ValidationResults;

                if (response.PaymentHistoryList == null || !response.PaymentHistoryList.Any()) continue;
                 Skip = response.PaymentHistoryList.Count;
                _PaymentHistoryList.AddRange(response.PaymentHistoryList);
            }
            while (Skip == Take);
        }

        private void assignCurrentPeriodAccountBalanceList()
        {
            if (!_Response.ValidationResults.IsValid) return;
            if (_CurrentPeriod == null) return;

            var response = DebtCollectionAccessProxy.GetAccountBalanceList(new GetAccountBalanceListRequest
            {
                PeriodIdList = new List<int> { _CurrentPeriod.Id }
            });

            _Response.ValidationResults = response.ValidationResults;

            _CurrentPeriodAccountBalanceList = response.AccountBalanceList;
        }      

        private void assignCurrentPeriodAccountOpeningBalanceList()
        {
            if (!_Response.ValidationResults.IsValid) return;
            if (_CurrentPeriod == null) return;

            var response = DebtCollectionAccessProxy.GetAccountOpeningBalanceList(new GetAccountOpeningBalanceListRequest
            {
                PeriodId = _CurrentPeriod.Id
            });

            _Response.ValidationResults = response.ValidationResults;
            _CurrentPeriodOpeningBalanceList = response.AccountOpeningBalanceList;
        }

        private void createAccountBalanceList()
        {
            if (!_Response.ValidationResults.IsValid) return;
            if (_CurrentPeriodAccountBalanceList != null && _CurrentPeriodAccountBalanceList.Any()) return;

            var response = CreateAccountBalanceListProcessor.CreateAccountBalanceList(new CreateAccountBalanceListRequest
            {
                CurrentPeriod = _CurrentPeriod,
                PaymentHistoryList = _PaymentHistoryList,
                PeriodList = _PeriodList,
                CompanyId = _Request.CompanyId
            });

            _Response.ValidationResults = response.ValidationResults;
        }

        private void updateAccountBalanceList()
        {
            if (!_Response.ValidationResults.IsValid) return;
            if (_CurrentPeriodAccountBalanceList == null || !_CurrentPeriodAccountBalanceList.Any()) return;

            var response = UpdateAccountBalanceProcessor.UpdateAccountBalanceList(new UpdateAccountBalanceProcessorRequest
            {
                CurrentPeriod = _CurrentPeriod,
                PeriodList = _PeriodList,
                CurrentPeriodAccountBalanceList = _CurrentPeriodAccountBalanceList,
                CurrentPeriodOpeningBalanceList = _CurrentPeriodOpeningBalanceList,
                PaymentHistoryList = _PaymentHistoryList,
                CompanyId = _Request.CompanyId,
            });

            _Response.ValidationResults = response.ValidationResults;
        }
    }
      
}