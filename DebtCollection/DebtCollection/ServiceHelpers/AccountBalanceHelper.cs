using AccountBalanceManager.Client;
using AccountBalanceManager.Operations;
using Newtonsoft.Json;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ServiceHelpers
{
    public interface IAccountBalanceHelper
    {
        GetAccountBalanceListResponse GetAccountBalanceList(DebtCollectionAccess.Contracts.GetAccountBalanceListRequest Request);
    }

    public class AccountBalanceHelper : IAccountBalanceHelper
    {
        #region Declarations

        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetAccountBalanceListResponse GetAccountBalanceList(DebtCollectionAccess.Contracts.GetAccountBalanceListRequest Request)
        {
            var accountBalanceManagerProxy = IOCManager.Resolve<IAccountBalanceManagerProxy>();
            var response = accountBalanceManagerProxy.GetAccountBalanceList(Request);

            //var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            //{
            //    Endpoint = @"accountBalance/list",
            //    RequestBody = Request,
            //    UseServiceUri = true,
            //});

            //var response = JsonConvert.DeserializeObject<GetAccountBalanceListResponse>(daoResponse.data);

            return response;
        }
    }
}
