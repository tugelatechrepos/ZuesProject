using DebtCollectionAccess.Dao;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IPersistPaymentHistoryPayloadPeriodOperation
    {
        PersistPaymentHistoryPayloadPeriodResponse PersistPaymentHistoryPayloadPeriod(PersistPaymentHistoryPayloadPeriodRequest Request);
    }

    public class PersistPaymentHistoryPayloadPeriodRequest
    {
        public PaymentHistoryPayloadPeriod PaymentHistoryPayloadPeriod { get; set; }
    }

    public class PersistPaymentHistoryPayloadPeriodResponse
    {
        public ValidationResults ValidationResults { get; set; }
    }

    public class PersistPaymentHistoryPayloadPeriodOperation : IPersistPaymentHistoryPayloadPeriodOperation
    {
        #region Declarations

        private PersistPaymentHistoryPayloadPeriodRequest _Request;
        private PersistPaymentHistoryPayloadPeriodResponse _Response;

        public IPaymentHistoryPayloadPeriodDao PaymentHistoryPayloadPeriodDao { get; set; }

        #endregion Declarations

        public PersistPaymentHistoryPayloadPeriodResponse PersistPaymentHistoryPayloadPeriod(PersistPaymentHistoryPayloadPeriodRequest Request)
        {
            _Request = Request;
            _Response = new PersistPaymentHistoryPayloadPeriodResponse { ValidationResults = new ValidationResults() };

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
            if (!_Response.ValidationResults.IsValid) return;

            _Response.ValidationResults = PaymentHistoryPayloadPeriodDao.PersistPaymentHistoryPayloadPeriod(_Request.PaymentHistoryPayloadPeriod,_Response.ValidationResults);
        }

    }
}
