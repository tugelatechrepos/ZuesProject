using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;

namespace DebtCollectionAccess.Operations
{
    public interface IGetAccountBalanceOperation
    {
        GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request);
    }

    
    public class GetAccountBalanceListOperation 
    {
        #region Declarations

        private GetAccountBalanceListRequest _Request;
        private GetAccountBalanceListResponse _Response;
        
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
