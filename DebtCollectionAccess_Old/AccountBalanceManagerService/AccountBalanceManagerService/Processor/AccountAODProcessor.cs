using AccountBalanceManagerService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Processor
{
    public interface IAccountAODProcessor
    {
        GetAccountAODListResponse GetAccountAODList(GetAccountAODListRequest Request);
    }

    public class GetAccountAODListRequest
    {
        public ICollection<int> AccountIdList { get; set; }
        public ICollection<int> PeriodIdList { get; set; }
    }

    public class GetAccountAODListResponse
    {
        public ICollection<AccountAod> AccountAODList { get; set; }
    }

 
    public class AccountAODProcessor : IAccountAODProcessor
    {
        #region Declarations

        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetAccountAODListResponse GetAccountAODList(GetAccountAODListRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = "accountAOD/list",
                RequestBody = Request
            });

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetAccountAODListResponse>(daoResponse.data);

            return response;
        }
    }
}