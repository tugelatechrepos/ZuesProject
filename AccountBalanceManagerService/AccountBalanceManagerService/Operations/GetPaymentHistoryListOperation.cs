using AccountBalanceManagerService.Contracts;
using AccountBalanceManagerService.Models;
using AccountBalanceManagerService.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Operations
{
    public interface IGetPaymentHistoryListOperation
    {
        GetPaymentHistoryListResponse GetPaymentHistoryList(GetPaymentHistoryListRequest Request);
    }

    public class GetPaymentHistoryListResponse
    {
        public ICollection<Contracts.PaymentHistory> PaymentHistoryList { get; set; }
    }

    public class GetPaymentHistoryListOperation : IGetPaymentHistoryListOperation
    {
        #region Declarations

        private GetPaymentHistoryListRequest _Request;
        private GetPaymentHistoryListResponse _Response;
        private ICollection<ServiceType> _ServiceTypeList;
        private List<Contracts.PaymentHistory> _PaymentHistoryList;

        public ITableTypeProcessor TableTypeProcessor { get; set; }
        public IPaymentHistoryProcessor PaymentHistoryProcessor { get; set; }

        #endregion Declarations

        public GetPaymentHistoryListResponse GetPaymentHistoryList(GetPaymentHistoryListRequest Request)
        {
            _Request = Request;
            _Response = new GetPaymentHistoryListResponse();

            assignServiceTypeList();
            assignPaymentHistoryList();

            _Response.PaymentHistoryList = _PaymentHistoryList;

            return _Response;
        }

        private void assignServiceTypeList()
        {
            var response = TableTypeProcessor.GetTableTypeList(new GetTableTypeProcessorRequest
            {
                IncludeServiceTypeList = true
            });

            _ServiceTypeList = response.ServiceTypeList;
        }

        private void assignPaymentHistoryList()
        {
            var response = PaymentHistoryProcessor.GetPaymentHistoryList(_Request);

            _PaymentHistoryList = response.PaymentHistoryList.Select(x => new Contracts.PaymentHistory
            {
                Id = x.Id,
                AccountId = x.AccountId,
                ServiceId = x.ServiceId,
                PaymentMode = x.PaymentMode,
                Amount = x.Amount,
                InvoiceId = x.InvoiceId,
                PaymentDate = x.PaymentDate,
                ServiceName = _ServiceTypeList?.FirstOrDefault(y => y.Id == x.ServiceId)?.Name
            }).ToList();

        }
    }
}