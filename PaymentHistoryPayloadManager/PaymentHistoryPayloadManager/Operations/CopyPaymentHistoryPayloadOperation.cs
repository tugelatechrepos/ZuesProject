using DebtCollectionAccess;
using DebtCollectionAccess.Client;
using Newtonsoft.Json;
using PaymentHistoryPayloadManager.Contracts;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentHistoryPayloadManager.Operations
{
    public interface ICopyPaymentHistoryPayloadOperation
    {
        CopyPaymentHistoryPayloadResponse CopyPaymentHistoryPayload(CopyPaymentHistoryPayloadRequest Request);
    }

    public class CopyPaymentHistoryPayloadRequest
    {
        public int PaymentHistoryPayloadPeriodId { get; set; }
    }


    public class CopyPaymentHistoryPayloadResponse
    {
        public ValidationResults ValidationResults { get; set; }
    }


    public class CopyPaymentHistoryPayloadOperation : ICopyPaymentHistoryPayloadOperation
    {
        #region Declarations

        private CopyPaymentHistoryPayloadRequest _Request;
        private CopyPaymentHistoryPayloadResponse _Response;
        private List<DebtCollectionAccess.PaymentHistoryPayload> _PaymentHistoryPayloadList;
        private List<PaymentHistory> _PaymentHistoryList;

        public IDebtCollectionAccessProxy DebtCollectionAccessProxy { get; set; }

        #endregion Declarations

        public CopyPaymentHistoryPayloadResponse CopyPaymentHistoryPayload(CopyPaymentHistoryPayloadRequest Request)
        {
            _Request = Request;
            _Response = new CopyPaymentHistoryPayloadResponse { ValidationResults = new ValidationResults() };

            assignPaymentHistoryPayloadList();
            persistPaymentHistoryList();

            return _Response;
        }

        private void assignPaymentHistoryPayloadList()
        {
            if (!_Response.ValidationResults.IsValid) return;

            _PaymentHistoryPayloadList = new List<DebtCollectionAccess.PaymentHistoryPayload>();

            int Skip = 0;
            int Take = 1000;
            do
            {
                var response = DebtCollectionAccessProxy.GetPaymentHistoryPayloadList(new DebtCollectionAccess.Operations.GetPaymentHistoryPayloadListRequest
                {
                    PaymentHistoryPayloadPeriodId = _Request.PaymentHistoryPayloadPeriodId,
                    Skip = Skip,
                    Take = Take
                });

                if (response.PaymentHistoryPayloadList == null || !response.PaymentHistoryPayloadList.Any()) continue;
                Skip = response.PaymentHistoryPayloadList.Count;
                _PaymentHistoryPayloadList.AddRange(_PaymentHistoryPayloadList);
            }
            while (Skip == Take);
        }

        private void persistPaymentHistoryList()
        {
            if (!_Response.ValidationResults.IsValid) return;
            if (_PaymentHistoryPayloadList == null || !_PaymentHistoryPayloadList.Any()) return;

            _PaymentHistoryList = new List<DebtCollectionAccess.PaymentHistory>();

            int Skip = 0;
            int Take = 1000;
            do
            {
                var paymentHistorypayloadList = _PaymentHistoryPayloadList.Skip(Skip).Take(Take);

                foreach (var paymentHistoryPayload in paymentHistorypayloadList)
                {
                    var paymentHistoryList = JsonConvert.DeserializeObject<ICollection<DebtCollectionAccess.PaymentHistory>>(paymentHistoryPayload.Payload);
                    _PaymentHistoryList.AddRange(paymentHistoryList);

                    var response =  DebtCollectionAccessProxy.PersistPaymentHistoryList(new DebtCollectionAccess.Contracts.PersistPaymentHistoryListRequest
                    {
                        PaymentHistoryList = paymentHistoryList
                    });
                }

                Skip = paymentHistorypayloadList.Count();
            }
            while (Skip == Take);         
        }
    }
}
