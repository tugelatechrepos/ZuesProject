using AccountBalanceManager.Client;
using AccountBalanceManager.Contracts;
using DebtCollectionAccess.Client;
using DebtCollectionAccess.Contracts;
using Newtonsoft.Json;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ServiceHelpers
{
    public interface IPeriodHelper
    {
        GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request);

        PersistPeriodListResponse PeristPeriodList(PersistPeriodListRequest Request);

        GetPeriodDetailListResponse GetPeriodDetail(GetPeriodDetailListRequest Request);
    }

    public class PeriodHelper : IPeriodHelper
    {
        #region Declarations

        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations


        public GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request)
        {
            var accessProxy = IOCManager.Resolve<IDebtCollectionAccessProxy>();
            var response = accessProxy.GetPeriodList(Request);

            //var daoHelperRequest = new DaoHelperRequest { Endpoint = @"period/list" };
            //var response = DaoHelper.Execute(daoHelperRequest);
            //var periodListResponse = JsonConvert.DeserializeObject<GetPeriodListResponse>(response.data);

            return response;
        }

        public PersistPeriodListResponse PeristPeriodList(PersistPeriodListRequest Request)
        {
            var accessProxy = IOCManager.Resolve<IDebtCollectionAccessProxy>();
            var response = accessProxy.PersistPeriodList(Request);

            //var daoHelperRequest = new DaoHelperRequest { Endpoint = @"period/persist" ,RequestBody = Request };
            //var daoResponse = DaoHelper.Execute(daoHelperRequest);
            //var response = JsonConvert.DeserializeObject<PersistPeriodListResponse>(daoResponse.data);

            return response;
        }

        public GetPeriodDetailListResponse GetPeriodDetail(GetPeriodDetailListRequest Request)
        {
            var accountBalanceManagerProxy = IOCManager.Resolve<IAccountBalanceManagerProxy>();
            var response = accountBalanceManagerProxy.GetPeriodDetailList(Request);

            //var daoHelperRequest = new DaoHelperRequest { Endpoint = @"period/detail", RequestBody = Request, UseServiceUri = true };
            //var daoResponse = DaoHelper.Execute(daoHelperRequest);
            //var response = JsonConvert.DeserializeObject<GetPeriodDetailListProcessorResponse>(daoResponse.data);
            return response;
        }
    }


}
