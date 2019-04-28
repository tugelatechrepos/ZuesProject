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

        public IDebtCollectionAccessProxy DebtCollectionAccessProxy { get; set; }

        #endregion Declarations

        public PersistPaymentHistoryPayloadListResponse PersistPaymentHistoryPayloadList(PersistPaymentHistoryPayloadListRequest Request)
        {
            _Request = Request;
            _Response = new PersistPaymentHistoryPayloadListResponse { ValidationResults = new ValidationResults() };

            persist();

            return _Response;
        }

        private void persist()
        {
            if (!_Response.ValidationResults.IsValid) return;

            var paymentHistoryPayloadPeriodList = _Request.PaymentHistoryPayloadList.Select(x => new DebtCollectionAccess.PaymentHistoryPayload
            {
                Id = x.Id,
                AccountId = x.AccountId,
                Payload = x.Payload,
                PaymentHistoryPayloadPeriodId = x.PaymentHistoryPayloadPeriodId
            }).ToList();

            var response = DebtCollectionAccessProxy.PersistPaymentHistoryPayloadList(new DebtCollectionAccess.Operations.PersistPaymentHistoryPayloadListRequest
            {
                PaymentHistoryPayloadList = paymentHistoryPayloadPeriodList
            });

            _Response.ValidationResults = response.ValidationResults;
        }
    }
}
