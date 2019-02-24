using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetAccountInceptionOperation
    {
        GetAccountInceptionListResponse GetAccountInceptionList(GetAccountInceptionListRequest Request);
    }

    public class GetAccountInceptionOperation : IGetAccountInceptionOperation
    {
        #region Declarations

        private GetAccountInceptionListRequest _Request;
        private GetAccountInceptionListResponse _Response;

        public IAccountInceptionDao AccountInceptionDao { get; set; }

        #endregion Declarations

        public GetAccountInceptionListResponse GetAccountInceptionList(GetAccountInceptionListRequest Request)
        {
            _Request = Request;
            _Response = new GetAccountInceptionListResponse();

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
            var accountInceptionList = AccountInceptionDao.GetAccountInceptionList(_Request);
            _Response.AccountInceptionList = accountInceptionList;
        }
    }
}
