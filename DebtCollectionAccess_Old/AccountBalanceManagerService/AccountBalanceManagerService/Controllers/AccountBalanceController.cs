using AccountBalanceManagerService.Operations;
using AccountBalanceManagerService.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AccountBalanceManagerService.Controllers
{

    [RoutePrefix("accountbalancemanager")]
    public class AccountBalanceController : ApiController
    {
        [HttpGet]
        [ActionName("maintain")]
        public void MaintainAccountBalanceRequest()
        {
            var processor = IocManager.Resolve<IAccountBalanceCalculationProcessor>();
            var response = processor.ProcessAccountBalanceList(new AccountBalanceCalculationProcessorRequest());
        }

        [HttpPost]
        [ActionName("list")]
        public Operations.GetAccountBalanceListResponse GetAccountBalanceList([FromBody]GetAccountBalanceListRequest Request)
        {
            var operation = IocManager.Resolve<IGetAccountBalanceListOperation>();
            var response = operation.GetAccountBalanceList(Request);
            return response;
        }
    }
}