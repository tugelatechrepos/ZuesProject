using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtCollectionAccess;
using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectCoreLibrary;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/commission")]
    public class CommissionController : Controller
    {
        [HttpPost]
        public GetCommissionResponse GetCommission([FromBody]GetCommissionRequest Request)
        {
            var operation = IOCManager.Resolve<IGetCommissionOperation>();
            var response = operation.GetCommission(new GetCommissionRequest { Yield = Request.Yield });

            return response;
        }
    }
}