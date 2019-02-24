using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using ProjectCoreLibrary;
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
            _Response = new GetPaymentHistoryListResponse { ValidationResults = new ValidationResults() };

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
                Skip = _Request.Skip,
                Take = _Request.Take
            } , 
            _Response.ValidationResults);

            _Response.PaymentHistoryList = response;
        }

    }
}
