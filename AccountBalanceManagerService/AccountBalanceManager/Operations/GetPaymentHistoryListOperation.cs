using DebtCollectionAccess;
using DebtCollectionAccess.Client;
using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountBalanceManager.Operations
{
    public interface IGetPaymentHistoryListOperation
    {
        GetPaymentHistoryListResponse GetPaymentHistoryList(GetPaymentHistoryListRequest Request);
    }

    public class GetPaymentHistoryListResponse
    {
        public ICollection<Contracts.PaymentHistory> PaymentHistoryList { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }

    public class GetPaymentHistoryListOperation : IGetPaymentHistoryListOperation
    {
        #region Declarations

        private GetPaymentHistoryListRequest _Request;
        private GetPaymentHistoryListResponse _Response;
        private ICollection<ServiceType> _ServiceTypeList;
        private List<Contracts.PaymentHistory> _PaymentHistoryList;

       public IDebtCollectionAccessProxy DebtCollectionAccessProxy { get; set; }

        #endregion Declarations

        public GetPaymentHistoryListResponse GetPaymentHistoryList(GetPaymentHistoryListRequest Request)
        {
            _Request = Request;
            _Response = new GetPaymentHistoryListResponse { ValidationResults = new ValidationResults() };

            assignServiceTypeList();
            assignPaymentHistoryList();

            _Response.PaymentHistoryList = _PaymentHistoryList;

            return _Response;
        }

        private void assignServiceTypeList()
        {
            var response = DebtCollectionAccessProxy.GetTypeTableList(new GetTypeTableListRequest
            {
                IncludeServiceTypeList = true
            });

            _Response.ValidationResults = response.ValidationResults;
            _ServiceTypeList = response.ServiceTypeList;
        }

        private void assignPaymentHistoryList()
        {
            var response = DebtCollectionAccessProxy.GetPaymentHistoryList(_Request);

            _Response.ValidationResults = response.ValidationResults;

            _PaymentHistoryList = response.PaymentHistoryList?.Select(x => new Contracts.PaymentHistory
            {
                Id = x.Id,
                AccountId = x.AccountId,
                ServiceId = x.ServiceId,
                PaymentMode = x.PaymentMode,
                Amount = x.Amount.Value,
                InvoiceId = x.InvoiceId,
                PaymentDate = x.PaymentDate,
                ServiceName = _ServiceTypeList?.FirstOrDefault(y => y.Id == x.ServiceId)?.Name
            }).ToList();

        }
    }
}