using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using ProjectCoreLibrary;
using System;

namespace DebtCollectionAccess.Operations
{
    public interface IGetAccountOpeningBalanceListOperation
    {
        GetAccountOpeningBalanceListResponse GetAccountOpeningBalanceList(GetAccountOpeningBalanceListRequest Request);
    }

    public class GetAccountOpeningBalanceListOperation : IGetAccountOpeningBalanceListOperation
    {
        #region Declarations

        private GetAccountOpeningBalanceListRequest _Request;
        private GetAccountOpeningBalanceListResponse _Response;

        public IAccountOpeningBalanceDao AccountOpeningBalanceDao { get; set; }

        #endregion Declarations

        public GetAccountOpeningBalanceListResponse GetAccountOpeningBalanceList(GetAccountOpeningBalanceListRequest Request)
        {
            _Request = Request;
            _Response = new GetAccountOpeningBalanceListResponse { ValidationResults = new ValidationResults() };

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
            var accountOpeningBalanceList = AccountOpeningBalanceDao.GetAccountOpeningBalanceList(_Request, _Response.ValidationResults);
            _Response.AccountOpeningBalanceList = accountOpeningBalanceList;
        }
    }
}
