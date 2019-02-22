using AccountBalanceManagerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Processor
{
    public interface IAccountOwnerProcessor
    {
        GetAccountOwnerListResponse GetAccountOwnerList(GetAccountOwnerListRequest Request);
    }

    public class GetAccountOwnerListRequest
    {
        public ICollection<int> AccountIdList { get; set; }
    }

    public class GetAccountOwnerListResponse
    {
        public ICollection<AccountOwner> AccountOwnerList { get; set; }
    }


    public class AccountOwnerProcessor : IAccountOwnerProcessor
    {
        #region Declarations

        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetAccountOwnerListResponse GetAccountOwnerList(GetAccountOwnerListRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"accountOwner/list",
                RequestBody = Request
            });

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetAccountOwnerListResponse>(daoResponse.data);

            return response;
        }
    }
}