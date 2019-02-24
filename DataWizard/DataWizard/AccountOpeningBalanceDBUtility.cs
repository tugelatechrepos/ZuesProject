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

    public class AccountOpeningBalanceDBUtility
    {
        public static PersistAccountOpeningBalanceListResponse PersistAccountOpeningBalanceList(PersistAccountOpeningBalanceListRequest Request)
        {
            var accessProxy = IOCManager.Resolve<IDebtCollectionAccessProxy>();
            var response = accessProxy.PersistAccountOpeningBalanceList(Request);
            //var daoHelper = new DaoHelper();

            //var daoResponse = daoHelper.Execute(new DaoHelperRequest
            //{
            //    Endpoint = @"accountOpeningBalance/persist",
            //    RequestBody = Request
            //});

            //var response = JsonConvert.DeserializeObject<PersistAccountOpeningBalanceListResponse>(daoResponse.data);

            return response;
        }
    }
}
