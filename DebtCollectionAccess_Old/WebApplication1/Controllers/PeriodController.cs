using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;
using DebtCollectionAccess;
using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;

using DebtCollectionAccess.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/period")]
    public class PeriodController : Controller
    {
        #region Declarations

        #endregion Declarations

        [HttpGet]
        [Route("list")]
        public GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request)
        {
            var operation = IocManager.Resolve<IGetPeriodListOperation>();
            var response = operation.GetPeriodList(Request);            
            return response;
        }

        [HttpPost]
        [Route("persist")]
        public PersistPeriodListResponse PersistPeriodList([FromBody]PersistPeriodListRequest Request)
        {
            var operation = IocManager.Resolve<IPersistPeriodListOperation>();

            var response = operation.PersistPeriodList(new PersistPeriodListRequest
            {
                PeriodList = Request.PeriodList
            });

            return response;
        }

    }
}