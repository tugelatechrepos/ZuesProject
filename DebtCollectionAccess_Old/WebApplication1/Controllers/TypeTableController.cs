using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtCollectionAccess;
using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/TypeTable")]
    public class TypeTableController : Controller
    {
        [HttpPost]
        [Route("list")]
        public GetTypeTableListResponse GetTypeTableList([FromBody] GetTypeTableListRequest Request)
        {
            var operation = IocManager.Resolve<IGetTypeTableListOperation>();
            var response = operation.GetTypeTableList(Request);
            return response;
        }
    }
}