using AccountBalanceManagerService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Processor
{
    public interface IAccountInceptionProcessor
    {
        GetAccountInceptionListResponse GetAccountInceptionList(GetAccountInceptionListRequest Request);
    }

    public class GetAccountInceptionListRequest
    {
        public ICollection<int> AccountIdList { get; set; }
    }

    public class GetAccountInceptionListResponse
    {
        public ICollection<AccountInception> AccountInceptionList { get; set; }
    }

   
    public class AccountInceptionProcessor : IAccountInceptionProcessor
    {
        #region Declarations

      
        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetAccountInceptionListResponse GetAccountInceptionList(GetAccountInceptionListRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = "accountInception/list",
                RequestBody = Request
            });

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetAccountInceptionListResponse>(daoResponse.data);

            return response;
        }
    }
}