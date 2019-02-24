using DebtCollectionAccess.Client;
using DebtCollectionAccess.Contracts;
using Newtonsoft.Json;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWizard
{

    public class PeriodDBUtility
    {
        public static GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request)
        {
            var accessProxy = IOCManager.Resolve<IDebtCollectionAccessProxy>();
            var response = accessProxy.GetPeriodList(Request);

            //var daoHelper = new DaoHelper();
            //var request = new GetPeriodListRequest();

            //var daoresponse = daoHelper.Execute(new DaoHelperRequest
            //{
            //    Endpoint = @"period/list"
            //});

            //var response = JsonConvert.DeserializeObject<GetPeriodListResponse>(daoresponse.data);

            return response;
        }

        public static PersistPeriodListResponse PersistPeriodList(PersistPeriodListRequest Request)
        {
            var accessProxy = IOCManager.Resolve<IDebtCollectionAccessProxy>();
            var response = accessProxy.PersistPeriodList(Request);
            //var daoHelper = new DaoHelper();

            //var daoresponse = daoHelper.Execute(new DaoHelperRequest
            //{
            //    Endpoint = @"period/persist",
            //    RequestBody = Request
            //});

            //var response = JsonConvert.DeserializeObject<PersistPeriodListResponse>(daoresponse.data);

            return response;
        }
    }
}
