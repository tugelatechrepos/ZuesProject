using DebtCollectionAccess.Dao;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetPaymentHistoryPayloadListOperation
    {
        GetPaymentHistoryPayloadListResponse GetPaymentHistoryPayloadList(GetPaymentHistoryPayloadListRequest Request);
    }

    public class GetPaymentHistoryPayloadListRequest
    {
        public int PaymentHistoryPayloadPeriodId { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }
    }

    public class GetPaymentHistoryPayloadListResponse
    {
        public ICollection<PaymentHistoryPayload> PaymentHistoryPayloadList { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }

    public class GetPaymentHistoryPayloadListOperation : IGetPaymentHistoryPayloadListOperation
    {
        #region Declarations

        private GetPaymentHistoryPayloadListRequest _Request;
        private GetPaymentHistoryPayloadListResponse _Response;

        public IPaymentHistoryPayloadDao PaymentHistoryPayloadDao { get; set; }

        #endregion Declarations

        public GetPaymentHistoryPayloadListResponse GetPaymentHistoryPayloadList(GetPaymentHistoryPayloadListRequest Request)
        {
            _Request = Request;
            _Response = new GetPaymentHistoryPayloadListResponse { ValidationResults = new ValidationResults() };

            assignList();

            return _Response;
        }

        private void assignList()
        {
            if (!_Response.ValidationResults.IsValid) return;

           _Response.PaymentHistoryPayloadList = PaymentHistoryPayloadDao.GetPaymentHistoryPayloadList(_Request.PaymentHistoryPayloadPeriodId, _Request.Skip, _Request.Take);
        }
    }
}
