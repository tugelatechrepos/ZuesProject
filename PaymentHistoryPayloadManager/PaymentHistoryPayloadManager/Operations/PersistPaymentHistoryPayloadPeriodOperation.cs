using DebtCollectionAccess.Client;
using PaymentHistoryPayloadManager.Contracts;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentHistoryPayloadManager.Operations
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
       public int PaymentHistoryPayloadPeriodId { get; set; }

       public ValidationResults ValidationResults { get; set; }
    }

    public class PersistPaymentHistoryPayloadPeriodOperation : IPersistPaymentHistoryPayloadPeriodOperation
    {
        #region Declarations

        private PersistPaymentHistoryPayloadPeriodRequest _Request;
        private PersistPaymentHistoryPayloadPeriodResponse _Response;

        public IDebtCollectionAccessProxy DebtCollectionAccessProxy { get; set; }

        #endregion Declarations

        public PersistPaymentHistoryPayloadPeriodResponse PersistPaymentHistoryPayloadPeriod(PersistPaymentHistoryPayloadPeriodRequest Request)
        {
            _Request = Request;
            _Response = new PersistPaymentHistoryPayloadPeriodResponse { ValidationResults = new ValidationResults() };

            persist();

            return _Response;
        }

        private void persist()
        {
            if (!_Response.ValidationResults.IsValid) return;

            var paymentHistoryPayloadPeriod = new DebtCollectionAccess.PaymentHistoryPayloadPeriod
            {
                Id = _Request.PaymentHistoryPayloadPeriod.Id,
                ClientId = _Request.PaymentHistoryPayloadPeriod.ClientId,
                CompanyId = _Request.PaymentHistoryPayloadPeriod.CompanyId,
                IsRunSuccessful = _Request.PaymentHistoryPayloadPeriod.IsRunSuccessful,
                RunDate = _Request.PaymentHistoryPayloadPeriod.RunDate
            };

            var response = DebtCollectionAccessProxy.PersistPaymentHistoryPayloadPeriod(new DebtCollectionAccess.Operations.PersistPaymentHistoryPayloadPeriodRequest
            {
                PaymentHistoryPayloadPeriod = paymentHistoryPayloadPeriod

            });

            _Response.ValidationResults = response.ValidationResults;
            _Response.PaymentHistoryPayloadPeriodId = _Response.PaymentHistoryPayloadPeriodId;
        }
    }
}
