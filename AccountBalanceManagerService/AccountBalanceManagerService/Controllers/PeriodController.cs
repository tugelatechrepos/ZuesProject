using AccountBalanceManager.Operations;
using AccountBalanceManagerService.Processor;
using AccountBalanceManager.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AccountBalanceManagerService.Controllers
{
    public class PeriodController : ApiController
    {
        [HttpPost]
        [ActionName("detail")]
        public GetPeriodDetailListProcessorResponse GetPeriodDetailList([FromBody]GetPeriodDetailListProcessorRequest Request)
        {
            var processor = IocManager.Resolve<IGetPeriodDetailListProcessor>();
            var response = processor.GetPeriodDetailList(Request);
            return response;
        }

        [HttpGet]
        [ActionName("list")]
        public AccountBalanceManager.Contracts.GetPeriodListResponse GetPeriodList([FromBody]AccountBalanceManager.Contracts.GetPeriodListRequest Request)
        {
            var operation = IocManager.Resolve<IGetPeriodListOperation>();
            var response = operation.GetPeriodList(Request);
            return response;
        }
      
    }
}