using DebtCollectionAccess.Dao;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetPaymentHistoryPayloadPeriodOperation
    {
        GetPaymentHistoryPayloadPeriodResponse GetPaymentHistoryPayloadPeriod(GetPaymentHistoryPayloadPeriodRequest Request);
    }

    public class GetPaymentHistoryPayloadPeriodRequest
    {
        public DateTime RunDate { get; set; }

        public int CompanyId { get; set; }

        public int ClientId { get; set; }
    }

    public class GetPaymentHistoryPayloadPeriodResponse
    {
        public PaymentHistoryPayloadPeriod PaymentHistoryPayloadPeriod { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }

    public class GetPaymentHistoryPayloadPeriodOperation : IGetPaymentHistoryPayloadPeriodOperation
    {
        #region Declarations

        private GetPaymentHistoryPayloadPeriodRequest _Request;
        private GetPaymentHistoryPayloadPeriodResponse _Response;

        public IPaymentHistoryPayloadPeriodDao PaymentHistoryPayloadPeriodDao { get; set; }

        #endregion Declarations

        public GetPaymentHistoryPayloadPeriodResponse GetPaymentHistoryPayloadPeriod(GetPaymentHistoryPayloadPeriodRequest Request)
        {
            _Request = Request;
            _Response = new GetPaymentHistoryPayloadPeriodResponse { ValidationResults = new ValidationResults() };

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
            if (!_Response.ValidationResults.IsValid) return;

            var paymentHistoryPayloadPeriod = PaymentHistoryPayloadPeriodDao.GetPaymentHistoryPayloadPeriod(_Request.RunDate, _Request.CompanyId, _Request.ClientId, _Response.ValidationResults);
            _Response.PaymentHistoryPayloadPeriod = paymentHistoryPayloadPeriod;
        }
    }
}
