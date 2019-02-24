using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetAccountBalanceOperation
    {
        GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request);
    }

    [Export(typeof(IGetAccountBalanceOperation))]
    public class GetAccountBalanceListOperation : IGetAccountBalanceOperation
    {
        #region Declarations

        private GetAccountBalanceListRequest _Request;
        private GetAccountBalanceListResponse _Response;

        [Import]
        public IAccountBalanceDao AccountBalanceDao { get; set; }
        
        #endregion Declarations

        public GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request)
        {
            _Request = Request;
            _Response = new GetAccountBalanceListResponse();

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
            _Response.AccountBalanceList = AccountBalanceDao.GetAccountBalanceList(_Request);
        }
    }
}
