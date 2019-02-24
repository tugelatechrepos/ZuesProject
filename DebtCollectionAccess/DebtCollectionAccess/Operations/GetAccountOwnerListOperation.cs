using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetAccountOwnerListOperation
    {
        GetAccountOwnerListResponse GetAccountOwnerList(GetAccountOwnerListRequest Request);
    }

    public class GetAccountOwnerListOperation : IGetAccountOwnerListOperation
    {
        #region Declarations

        private GetAccountOwnerListRequest _Request;
        private GetAccountOwnerListResponse _Response;

        public IAccountOwnerDao AccountOwnerDao { get; set; }

        #endregion Declarations

        public GetAccountOwnerListResponse GetAccountOwnerList(GetAccountOwnerListRequest Request)
        {
            _Request = Request;
            _Response = new GetAccountOwnerListResponse { ValidationResults = new ValidationResults() };

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
            var accountOwnerList = AccountOwnerDao.GetAccountOwnerList(_Request, _Response.ValidationResults);
            _Response.AccountOwnerList = accountOwnerList;
        }
    }
}
