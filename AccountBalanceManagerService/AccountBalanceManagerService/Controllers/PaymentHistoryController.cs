using AccountBalanceManagerService.Operations;
using AccountBalanceManagerService.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AccountBalanceManagerService.Controllers
{
    [RoutePrefix("paymentHistory")]
    public class PaymentHistoryController : ApiController
    {
        [HttpPost]
        [ActionName("list")]
        public Operations.GetPaymentHistoryListResponse GetPaymentHistoryList([FromBody]GetPaymentHistoryListRequest Request)
        {
            var operation = IocManager.Resolve<IGetPaymentHistoryListOperation>();
            var response = operation.GetPaymentHistoryList(Request);
            return response;
        }
    }
}