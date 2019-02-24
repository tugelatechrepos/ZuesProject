using AccountBalanceManagerService.Contracts;
using AccountBalanceManagerService.Models;
using AccountBalanceManagerService.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Operations
{
    public interface IGetAccountBalanceListOperation
    {
        GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request);
    }

    public class GetAccountBalanceListResponse
    {
        public ICollection<Contracts.AccountBalance> AccountBalanceList { get; set; }
    }

    public class GetAccountBalanceListOperation : IGetAccountBalanceListOperation
    {
        #region Declaration

        private GetAccountBalanceListRequest _Request;
        private GetAccountBalanceListResponse _Response;
        private ICollection<Contracts.AccountBalance> _AccountBalanceList;
        private ICollection<Users> _UserList;

        public IAccountBalanceProcessor AccountBalanceProcessor { get; set; }
        public ITableTypeProcessor TableTypeProcessor { get; set; }

        #endregion Declaration

        public GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request)
        {
            _Request = Request;
            _Response = new GetAccountBalanceListResponse();

            assignUserList();
            assignAccountBalanceList();

            return _Response;
        }

        private void assignUserList()
        {
            var response = TableTypeProcessor.GetTableTypeList(new GetTableTypeProcessorRequest { IncludeUserList = true });

            _UserList = response.UserList;
        }
    
        private void assignAccountBalanceList()
        {
            var response  = AccountBalanceProcessor.GetAccountBalanceList(_Request);

            var accountBalanceList = response.AccountBalanceList;

            _AccountBalanceList = accountBalanceList?.Select(x => new Contracts.AccountBalance
            {
                Id = x.Id,
                AccountId = x.AccountId,
                OpeningBalance = x.OpeningBalance,
                PeriodId = x.PeriodId,
                Paid = x.Paid,
                PromisedAmount = x.PromisedAmount,
                RemainingBalance = x.RemainingBalance,
                IsPartialPayment = x.IsPartialPayment,
                IsPaymentMissed = x.IsPaymentMissed,
                OwnerName = getOwnerName(x.OwnerId)
            }).ToList();

            _Response.AccountBalanceList = _AccountBalanceList;
        } 
        
        private string getOwnerName(int? OwnerId)
        {
            string OwnerName = string.Empty;
            if (_UserList == null || !_UserList.Any()) return OwnerName;
            if (!OwnerId.HasValue) return OwnerName;
            var user = _UserList.FirstOrDefault(x => x.Id == OwnerId.Value);
            if(user == null) return OwnerName;
            OwnerName = $"{user.FirstName} {user.LastName}";
            return OwnerName;
        }

    }
}