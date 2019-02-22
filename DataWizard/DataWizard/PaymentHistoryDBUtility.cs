using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWizard
{
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


    public class PaymentHistoryDBUtility
    {

        public static ICollection<PaymentHistory> GetData(GetPaymentHistoryListRequest Request)
        {
            var daoHelper = new DaoHelper();

            var daoResponse = daoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"paymentHistory/list",
                RequestBody = Request,
                UseServiceUri = true,
            });

            var response = JsonConvert.DeserializeObject<GetPaymentHistoryListResponse>(daoResponse.data);

            return response.PaymentHistoryList;
        }

        public static void PersistData(ICollection<PaymentHistory> PaymentHistoryList)
        {
            var daoHelper = new DaoHelper();

            var request = new PersistPaymentHistoryListRequest
            {
                PaymentHistoryList = PaymentHistoryList
            };

            var daoResponse = daoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"paymentHistory/persist",
                RequestBody = request
            });

            var response = JsonConvert.DeserializeObject<PersistPaymentHistoryListResponse>(daoResponse.data);
        }
    }
}
