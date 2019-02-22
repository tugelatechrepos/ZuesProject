using DebtCollection.ViewModel;
using Newtonsoft.Json;
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

        GetPeriodDetailListProcessorResponse GetPeriodDetail(GetPeriodDetailListProcessorRequest Request);
    }

    public class GetPeriodListResponse
    {
        public ICollection<Period> PeriodList { get; set; }
    }

    public class PersistPeriodListRequest
    {
        public ICollection<Period> PeriodList { get; set; }
    }

    public class PersistPeriodListResponse
    {
        
    }

    public class PeriodHelper : IPeriodHelper
    {
        #region Declarations

        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations


        public GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request)
        {
            var daoHelperRequest = new DaoHelperRequest { Endpoint = @"period/list" };
            var response = DaoHelper.Execute(daoHelperRequest);
            var periodListResponse = JsonConvert.DeserializeObject<GetPeriodListResponse>(response.data);
            return periodListResponse;
        }

        public PersistPeriodListResponse PeristPeriodList(PersistPeriodListRequest Request)
        {
            var daoHelperRequest = new DaoHelperRequest { Endpoint = @"period/persist" ,RequestBody = Request };
            var daoResponse = DaoHelper.Execute(daoHelperRequest);
            var response = JsonConvert.DeserializeObject<PersistPeriodListResponse>(daoResponse.data);

            return response;
        }

        public GetPeriodDetailListProcessorResponse GetPeriodDetail(GetPeriodDetailListProcessorRequest Request)
        {
            var daoHelperRequest = new DaoHelperRequest { Endpoint = @"period/detail" , RequestBody = Request, UseServiceUri = true};
            var daoResponse = DaoHelper.Execute(daoHelperRequest);
            var response = JsonConvert.DeserializeObject<GetPeriodDetailListProcessorResponse>(daoResponse.data);
            return response;
        }
    }


}
