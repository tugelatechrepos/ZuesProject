using AccountBalanceManagerService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Processor
{
    public interface IAccountOpeningBalanceProcessor
    {
        GetAccountOpeningBalanceListResponse GetAccountOpeningBalanceListRequest(GetAccountOpeningBalanceListRequest Request);
    }

    public class GetAccountOpeningBalanceListRequest
    {
        public int PeriodId { get; set; }
    }

    public class GetAccountOpeningBalanceListResponse
    {
        public ICollection<AccountOpeningBalance> AccountOpeningBalanceList { get; set; }
    }

   
    public class AccountOpeningBalanceProcessor : IAccountOpeningBalanceProcessor
    {
        #region Declarations

       
        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetAccountOpeningBalanceListResponse GetAccountOpeningBalanceListRequest(GetAccountOpeningBalanceListRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = "accountOpeningBalance/list",
                RequestBody = Request
            });

            var getAccountOpeningBalanceListResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<GetAccountOpeningBalanceListResponse>(daoResponse.data);

            return getAccountOpeningBalanceListResponse;
        }
    }
}