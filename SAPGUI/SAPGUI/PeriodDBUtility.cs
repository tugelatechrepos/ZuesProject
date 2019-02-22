using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPGUI
{
    public class Period
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime? RunDate { get; set; }
    }


    public class GetPeriodListRequest
    {
        public ICollection<int> PeriodIdList { get; set; }
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

    public class PeriodDBUtility
    {
        public static GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request)
        {
            var daoHelper = new DaoHelper();
            var request = new GetPeriodListRequest();

            var daoresponse = daoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"period/list"
            });

            var response = JsonConvert.DeserializeObject<GetPeriodListResponse>(daoresponse.data);

            return response;
        }

        public static PersistPeriodListResponse PersistPeriodList(PersistPeriodListRequest Request)
        {
            var daoHelper = new DaoHelper();

            var daoresponse = daoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"period/persist",
                RequestBody = Request
            });

            var response = JsonConvert.DeserializeObject<PersistPeriodListResponse>(daoresponse.data);

            return response;
        }
    }
}
