using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;

namespace DebtCollectionAccess.Operations
{
    public interface IGetAccountAODListOperation
    {
        GetAccountAODListResponse GetAccountAODList(GetAccountAODListRequest Request);
    }

    public class GetAccountAODListOperation : IGetAccountAODListOperation
    {
        #region Declarations

        private GetAccountAODListRequest _Request;
        private GetAccountAODListResponse _Response;

        public IAccountAODDao AccountAODDao { get; set; }

        #endregion Declarations

        public GetAccountAODListResponse GetAccountAODList(GetAccountAODListRequest Request)
        {
            _Request = Request;
            _Response = new GetAccountAODListResponse();

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
            var accountAODList =  AccountAODDao.GetAccountAODList(_Request);

            _Response.AccountAODList = accountAODList;
        }
    }
}
