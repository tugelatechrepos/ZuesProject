using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Operations;
using Microsoft.AspNetCore.Mvc;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtCollectionAccessService.Controllers
{
    [Produces("application/json")]
    [Route("api/clientList")]
    public class ClientListController : Controller
    {
        [HttpPost]
        [Route("list")]
        public GetClientListResponse GetClientList([FromBody]GetClientListRequest Request)
        {
            var operation = IOCManager.Resolve<IGetClientListOperation>();
            var resultList = operation.GetClientList(Request);

            return resultList;
        }
    }
}
