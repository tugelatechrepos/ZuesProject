using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IPersistPaymentHistoryListOperation
    {
        PersistPaymentHistoryListResponse PersistPaymentHistoryList(PersistPaymentHistoryListRequest Request);
    }

    public class PersistPaymentHistoryListOperation : IPersistPaymentHistoryListOperation
    {
        #region Declarations

        private PersistPaymentHistoryListRequest _Request;
        private PersistPaymentHistoryListResponse _Response;

        public IPaymentHistoryDao PaymentHistoryDao { get; set; }

        #endregion Declarations

        public PersistPaymentHistoryListResponse PersistPaymentHistoryList(PersistPaymentHistoryListRequest Request)
        {
            _Request = Request;
            _Response = new PersistPaymentHistoryListResponse();

            persist();

            return _Response;
        }

        private void persist()
        {
          _Response.ValidationResults = PaymentHistoryDao.PersistPaymentHistoryList(_Request);
        }
    }
}
