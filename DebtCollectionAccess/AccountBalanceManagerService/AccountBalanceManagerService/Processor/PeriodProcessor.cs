using AccountBalanceManagerService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Processor
{
    public interface IPeriodProcessor
    {
        GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request);
    }

    public class GetPeriodListRequest
    {

    }

    public class GetPeriodListResponse
    {
        public ICollection<Period> PeriodList { get; set; }
    }

   
    public class PeriodProcessor : IPeriodProcessor
    {
        #region Declarations

        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"period/list",
            });

            var getPeriodListResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<GetPeriodListResponse>(daoResponse.data);

            return getPeriodListResponse;
        }
    }
}