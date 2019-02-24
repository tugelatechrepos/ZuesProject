using DebtCollectionAccess;
using DebtCollectionAccess.Client;
using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountBalanceManager.Operations
{
    public interface IGetAccountBalanceListOperation
    {
        GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request);
    }

    public class GetAccountBalanceListResponse
    {
        public ICollection<Contracts.AccountBalance> AccountBalanceList { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }

    public class GetAccountBalanceListOperation : IGetAccountBalanceListOperation
    {
        #region Declaration

        private GetAccountBalanceListRequest _Request;
        private GetAccountBalanceListResponse _Response;
        private ICollection<Contracts.AccountBalance> _AccountBalanceList;
        private ICollection<Users> _UserList;

        public IDebtCollectionAccessProxy DebtCollectionAccessProxy { get; set; }

        #endregion Declaration

        public GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request)
        {
            _Request = Request;
            _Response = new GetAccountBalanceListResponse { ValidationResults = new ValidationResults() };

            assignUserList();
            assignAccountBalanceList();

            return _Response;
        }

        private void assignUserList()
        {
            var response = DebtCollectionAccessProxy.GetTypeTableList(new GetTypeTableListRequest
            {
                IncludeUserList = true
            });

            _Response.ValidationResults = response.ValidationResults;
            _UserList = response.UserList;
        }
    
        private void assignAccountBalanceList()
        {
            var response  = DebtCollectionAccessProxy.GetAccountBalanceList(_Request);

            _Response.ValidationResults = response.ValidationResults;

            var accountBalanceList = response.AccountBalanceList;

            _AccountBalanceList = accountBalanceList?.Select(x => new Contracts.AccountBalance
            {
                Id = x.Id,
                AccountId = x.AccountId,
                OpeningBalance = Convert.ToDecimal(x.OpeningBalance),
                PeriodId = x.PeriodId.Value,
                Paid = Convert.ToDecimal(x.Paid),
                PromisedAmount = Convert.ToDecimal(x.PromisedAmount),
                RemainingBalance = Convert.ToDecimal(x.RemainingBalance),
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