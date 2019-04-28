using DebtCollectionAccess.Dao;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IPersistPaymentHistoryPayloadListOperation
    {
        PersistPaymentHistoryPayloadListResponse PersistPaymentHistoryPayloadList(PersistPaymentHistoryPayloadListRequest Request);
    }

    public class PersistPaymentHistoryPayloadListRequest
    {
        public ICollection<PaymentHistoryPayload> PaymentHistoryPayloadList { get; set; }
    }

    public class PersistPaymentHistoryPayloadListResponse
    {
        public ValidationResults ValidationResults { get; set; }
    }

    public class PersistPaymentHistoryPayloadListOperation : IPersistPaymentHistoryPayloadListOperation
    {
        #region Declarations

        private PersistPaymentHistoryPayloadListRequest _Request;
        private PersistPaymentHistoryPayloadListResponse _Response;

        public IPaymentHistoryPayloadDao PaymentHistoryPayloadDao { get; set; }

        #endregion Declarations

        public PersistPaymentHistoryPayloadListResponse PersistPaymentHistoryPayloadList(PersistPaymentHistoryPayloadListRequest Request)
        {
            _Request = Request;
            _Response = new PersistPaymentHistoryPayloadListResponse { ValidationResults = new ValidationResults() };

            persistList();

            return _Response;
        }

        private void persistList()
        {
            if (!_Response.ValidationResults.IsValid) return;

            _Response.ValidationResults = PaymentHistoryPayloadDao.PersistPaymentHistoryPayloadList(_Request.PaymentHistoryPayloadList, _Response.ValidationResults);
        }
    }
}
