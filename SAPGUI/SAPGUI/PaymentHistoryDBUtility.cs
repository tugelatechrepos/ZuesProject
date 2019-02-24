using AccountBalanceManager.Client;
using AccountBalanceManager.Contracts;
using DebtCollectionAccess.Client;
using DebtCollectionAccess.Contracts;
using Newtonsoft.Json;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPGUI
{

    //public class GetPaymentHistoryListRequest
    //{
    //    public DateTime FromDate { get; set; }
    //    public DateTime? ToDate { get; set; }
    //    public ICollection<int> AccountIdList { get; set; }
    //    public int? InvoiceId { get; set; }
    //    public int Skip { get; set; }
    //    public int Take { get; set; }
    //}

    //public class GetPaymentHistoryListResponse
    //{
    //    public ICollection<PaymentHistory> PaymentHistoryList { get; set; }
    //}

    //public class PersistPaymentHistoryListRequest
    //{
    //    public ICollection<PaymentHistory> PaymentHistoryList { get; set; }
    //}

    //public class PersistPaymentHistoryListResponse
    //{

    //}


    public class PaymentHistoryDBUtility
    {
        public ICollection<PaymentHistory> GetData(GetPaymentHistoryListRequest Request)
        {
            var accountBalanceManagerProxy = IOCManager.Resolve<IAccountBalanceManagerProxy>();

            var response = accountBalanceManagerProxy.GetPaymentHistoryList(Request);

            //var daoHelper = new DaoHelper();

            //var daoResponse = daoHelper.Execute(new DaoHelperRequest
            //{
            //    Endpoint = @"paymentHistory/list",
            //    RequestBody = Request,
            //    UseServiceUri = true,
            //});

            //var response = JsonConvert.DeserializeObject<GetPaymentHistoryListResponse>(daoResponse.data);

            return response.PaymentHistoryList;
        }

        public void PersistData(ICollection<DebtCollectionAccess.PaymentHistory> PaymentHistoryList)
        {
            var debtCollectionAccessProxy = IOCManager.Resolve<IDebtCollectionAccessProxy>();
            var response = debtCollectionAccessProxy.PersistPaymentHistoryList(new DebtCollectionAccess.Contracts.PersistPaymentHistoryListRequest
            {
                PaymentHistoryList = PaymentHistoryList
            });

            //var daoHelper = new DaoHelper();

            //var request = new PersistPaymentHistoryListRequest
            //{
            //   PaymentHistoryList = PaymentHistoryList
            //};

            //var daoResponse = daoHelper.Execute(new DaoHelperRequest
            //{
            //    Endpoint = @"paymentHistory/persist",
            //    RequestBody = request
            //});

            //var response = JsonConvert.DeserializeObject<PersistPaymentHistoryListResponse>(daoResponse.data);
        }
    }
}
