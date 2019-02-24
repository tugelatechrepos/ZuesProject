using AccountBalanceManagerService.Processor;
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
    }
}