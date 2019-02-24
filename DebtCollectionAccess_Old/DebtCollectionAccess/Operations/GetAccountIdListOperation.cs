using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetAccountIdListOperation
    {
        GetAccountIdListResponse GetAccountIdList();
    }

    public class GetAccountIdListOperation : IGetAccountIdListOperation
    {
        #region Declarations

        private GetAccountIdListResponse _Response;

        public IPaymentHistoryDao PaymentHistoryDao { get; set; }

        #endregion Declarations

        public GetAccountIdListResponse GetAccountIdList()
        {
            _Response = new GetAccountIdListResponse();

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
            var accountIdList = PaymentHistoryDao.GetAccountIdListFromPaymentHistory();

            _Response.AccountIdList = accountIdList;
        }
    }
}
