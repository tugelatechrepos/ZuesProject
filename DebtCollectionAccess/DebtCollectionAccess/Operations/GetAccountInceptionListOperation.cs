using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetAccountInceptionListOperation
    {
        GetAccountInceptionListResponse GetAccountInceptionList(GetAccountInceptionListRequest Request);
    }

    public class GetAccountInceptionListOperation : IGetAccountInceptionListOperation
    {
        #region Declarations

        private GetAccountInceptionListRequest _Request;
        private GetAccountInceptionListResponse _Response;

        public IAccountInceptionDao AccountInceptionDao { get; set; }

        #endregion Declarations

        public GetAccountInceptionListResponse GetAccountInceptionList(GetAccountInceptionListRequest Request)
        {
            _Request = Request;
            _Response = new GetAccountInceptionListResponse { ValidationResults = new ValidationResults() };

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
            var accountInceptionList = AccountInceptionDao.GetAccountInceptionList(_Request, _Response.ValidationResults);
            _Response.AccountInceptionList = accountInceptionList;
        }
    }
}
