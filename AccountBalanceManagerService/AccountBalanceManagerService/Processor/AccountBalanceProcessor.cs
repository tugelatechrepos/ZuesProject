using AccountBalanceManagerService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Processor
{
    public interface IAccountBalanceProcessor
    {
        GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request);

        PersistAccoutBalanceListResponse PersistAccountBalanceList(PersistAccountBalanceListRequest Request);
    }

    public class GetAccountBalanceListRequest
    {
        public ICollection<int> PeriodIdList { get; set; }
    }

    public class GetAccountBalanceListResponse
    {
        public ICollection<AccountBalance> AccountBalanceList { get; set; }
    }

    public class PersistAccountBalanceListRequest
    {
        public ICollection<AccountBalance> AccountBalanceList { get; set; }
    }

    public class PersistAccoutBalanceListResponse
    {

    }

  
    public class AccountBalanceProcessor : IAccountBalanceProcessor
    {
        #region Declarations

       
        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = "accountBalance/list",
                RequestBody = Request
            });

            var getAccoutBalanceListResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<GetAccountBalanceListResponse>(daoResponse.data);

            return getAccoutBalanceListResponse;
        }

        public PersistAccoutBalanceListResponse PersistAccountBalanceList(PersistAccountBalanceListRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = "accountBalance/persist",
                RequestBody = Request
            });

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<PersistAccoutBalanceListResponse>(daoResponse.data);

            return response;
        }
    }
}