using DebtCollection.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ServiceHelpers
{
    public interface IPaymentHistoryHelper
    {
        GetPaymentHistoryListResponse GetPaymentHistoryList(GetPaymentHistoryListRequest Request);

        PersistPaymentHistoryListResponse Persist(PersistPaymentHistoryListRequest Request);

        GetAccountIdListResponse GetAccountIdList(GetAccountIdListRequest Request);
    }


    public class PaymentHistoryHelper : IPaymentHistoryHelper
    {
        #region Declarations

        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetPaymentHistoryListResponse GetPaymentHistoryList(GetPaymentHistoryListRequest Request)
        {
            var response = new GetPaymentHistoryListResponse();

            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"paymentHistory/list",
                RequestBody = Request,
                UseServiceUri = true,
            });

            response = JsonConvert.DeserializeObject<GetPaymentHistoryListResponse>(daoResponse.data);
            return response;
        }

        public PersistPaymentHistoryListResponse Persist(PersistPaymentHistoryListRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"paymentHistory/persist",
                RequestBody = Request
            });

            var response = JsonConvert.DeserializeObject<PersistPaymentHistoryListResponse>(daoResponse.data);
            return response;
        }

        public GetAccountIdListResponse GetAccountIdList(GetAccountIdListRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"paymentHistory/accountlist",
            });

            var response = JsonConvert.DeserializeObject<GetAccountIdListResponse>(daoResponse.data);
            return response;
        }
    }
}
