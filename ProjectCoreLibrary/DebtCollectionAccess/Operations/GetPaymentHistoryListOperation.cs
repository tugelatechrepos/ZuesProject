using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetPaymentHistoryListOperation
    {
        GetPaymentHistoryListResponse GetPaymentHistoryList(Contracts.GetPaymentHistoryListRequest Request);

    }

    public class GetPaymentHistoryListOperation : IGetPaymentHistoryListOperation
    {
        #region Declarations

        private Contracts.GetPaymentHistoryListRequest _Request;
        private GetPaymentHistoryListResponse _Response;

        public IPaymentHistoryDao PaymentHistoryDao { get; set; }

        #endregion Declarations

        public GetPaymentHistoryListResponse GetPaymentHistoryList(Contracts.GetPaymentHistoryListRequest Request)
        {
            _Request = Request;
            _Response = new GetPaymentHistoryListResponse();

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
            var response = PaymentHistoryDao.GetPaymentHistoryList(new Dao.GetPaymentHistoryListRequest
            {
                AccountIdList = _Request.AccountIdList,
                FromDate = _Request.FromDate,
                ToDate = _Request.ToDate,
                InvoiceId = _Request.InvoiceId,
            });

            _Response.PaymentHistoryList = response;
        }

    }
}
