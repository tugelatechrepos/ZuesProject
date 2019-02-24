using AccountBalanceManagerService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Processor
{
    public interface IPaymentHistoryProcessor
    {
        GetPaymentHistoryListResponse GetPaymentHistoryList(GetPaymentHistoryListRequest Request);

        PersistPaymentHistoryListResponse PersistPaymentHistoryList(PersistPaymentHistoryListRequest Request);
    }

    public class GetPaymentHistoryListRequest
    {
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public ICollection<int> AccountIdList { get; set; }
        public int? InvoiceId { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }

    public class GetPaymentHistoryListResponse
    {
        public ICollection<PaymentHistory> PaymentHistoryList { get; set; }
    }

    public class PersistPaymentHistoryListRequest
    {
        public ICollection<PaymentHistory> PaymentHistoryList { get; set; }
    }

    public class PersistPaymentHistoryListResponse
    {

    }

   
    public class PaymentHistoryProcessor : IPaymentHistoryProcessor
    {
        #region Declarations

      
        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetPaymentHistoryListResponse GetPaymentHistoryList(GetPaymentHistoryListRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"paymentHistory/list",
                RequestBody = Request
            });

            var getPaymentHistoryListResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<GetPaymentHistoryListResponse>(daoResponse.data);

            return getPaymentHistoryListResponse;
        }

        public PersistPaymentHistoryListResponse PersistPaymentHistoryList(PersistPaymentHistoryListRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"paymentHistory/persist",
                RequestBody = Request
            });

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<PersistPaymentHistoryListResponse>(daoResponse.data);

            return response;
        }
    }
}