using DebtCollectionAccess;
using DebtCollectionAccess.Client;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentHistoryPayloadManager.Operations
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

        public IDebtCollectionAccessProxy DebtCollectionAccessProxy { get; set; }

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

            var response = DebtCollectionAccessProxy.GetPaymentHistoryPayloadPeriod(new DebtCollectionAccess.Operations.GetPaymentHistoryPayloadPeriodRequest
            {
                RunDate = _Request.RunDate,
                ClientId = _Request.ClientId,
                CompanyId = _Request.CompanyId
            });

            _Response.PaymentHistoryPayloadPeriod = response.PaymentHistoryPayloadPeriod;
        }
    }
}
