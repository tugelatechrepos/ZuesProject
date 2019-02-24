using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using AccountBalanceManagerService.Models;

namespace AccountBalanceManagerService.Processor
{
    public interface IAccountBalanceCalculationProcessor
    {
        AccountBalanceCalculationProcessorResponse ProcessAccountBalanceList(AccountBalanceCalculationProcessorRequest Request);
    }

    public class AccountBalanceCalculationProcessorRequest
    {

    }

    public class AccountBalanceCalculationProcessorResponse
    {

    }

   
    public class AccountBalanceCalculationProcessor : IAccountBalanceCalculationProcessor
    {

        #region Declarations

        private ICollection<Period> _PeriodList;
        private Period _CurrentPeriod;
        private List<PaymentHistory> _PaymentHistoryList;
        private ICollection<AccountBalance> _CurrentPeriodAccountBalanceList;
        private ICollection<AccountOpeningBalance> _CurrentPeriodOpeningBalanceList;

      
        public IPeriodProcessor PeriodProcessor { get; set; }
       
        public IPaymentHistoryProcessor PaymentHistoryProcessor { get; set; }
        
        public IAccountBalanceProcessor AccountBalanceProcessor { get; set; }
        
        public IAccountOpeningBalanceProcessor AccountOpeningBalanceProcessor { get; set; }
        
        public ICreateAccountBalanceListProcessor CreateAccountBalanceListProcessor { get; set; }
       
        public IUpdateAccountBalanceProcessor UpdateAccountBalanceProcessor { get; set; }

        #endregion Declarations

        public AccountBalanceCalculationProcessorResponse ProcessAccountBalanceList(AccountBalanceCalculationProcessorRequest Request)
        {
            var response = new AccountBalanceCalculationProcessorResponse();

            execute();

            return response;
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
            var response = PeriodProcessor.GetPeriodList(new GetPeriodListRequest());

            _PeriodList = response.PeriodList;
        }

        private void assignCurrentPeriod()
        {
            if (_PeriodList == null || !_PeriodList.Any()) return;

            var currentMonth = DateTime.Now.Date.Month;
            var currentYear = DateTime.Now.Date.Year;

            _CurrentPeriod = _PeriodList.FirstOrDefault(x => x.FromDate.Month == currentMonth && x.FromDate.Year == currentYear);
        }

        private void assignPaymentHistoryList()
        {
            _PaymentHistoryList = new List<PaymentHistory>();

            int Skip = 0;
            int Take = 1000;
            do
            {
                var response = PaymentHistoryProcessor.GetPaymentHistoryList(new GetPaymentHistoryListRequest
                {
                    Skip = Skip,
                    Take = Take
                });

                if (response.PaymentHistoryList == null || !response.PaymentHistoryList.Any()) continue;
                Skip = response.PaymentHistoryList.Count;
                _PaymentHistoryList.AddRange(response.PaymentHistoryList);
            }
            while (Skip == Take);
        }

        private void assignCurrentPeriodAccountBalanceList()
        {
            if (_CurrentPeriod == null) return;

            var response = AccountBalanceProcessor.GetAccountBalanceList(new GetAccountBalanceListRequest
            {
                PeriodIdList = new List<int> { _CurrentPeriod.Id }
            });

            _CurrentPeriodAccountBalanceList = response.AccountBalanceList;
        }      

        private void assignCurrentPeriodAccountOpeningBalanceList()
        {
            if (_CurrentPeriod == null) return;

            var response = AccountOpeningBalanceProcessor.GetAccountOpeningBalanceListRequest(new GetAccountOpeningBalanceListRequest
            {
                PeriodId = _CurrentPeriod.Id
            });

            _CurrentPeriodOpeningBalanceList = response.AccountOpeningBalanceList;
        }

        private void createAccountBalanceList()
        {
            if (_CurrentPeriodAccountBalanceList != null && _CurrentPeriodAccountBalanceList.Any()) return;

            var response = CreateAccountBalanceListProcessor.CreateAccountBalanceList(new CreateAccountBalanceListRequest
            {
                CurrentPeriod = _CurrentPeriod,
                PaymentHistoryList = _PaymentHistoryList,
                PeriodList = _PeriodList
            });
        }

        private void updateAccountBalanceList()
        {
            if (_CurrentPeriodAccountBalanceList == null || !_CurrentPeriodAccountBalanceList.Any()) return;

            var response = UpdateAccountBalanceProcessor.UpdateAccountBalanceList(new UpdateAccountBalanceProcessorRequest
            {
                CurrentPeriod = _CurrentPeriod,
                PeriodList = _PeriodList,
                CurrentPeriodAccountBalanceList = _CurrentPeriodAccountBalanceList,
                CurrentPeriodOpeningBalanceList = _CurrentPeriodOpeningBalanceList,
                PaymentHistoryList = _PaymentHistoryList
            });
        }
    }

      
}