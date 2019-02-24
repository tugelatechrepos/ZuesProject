using DebtCollectionAccess.Client;
using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Operations;
using Microsoft.AspNetCore.Mvc;
using ProjectCoreLibrary;

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
            var accessProxy = IOCManager.Resolve<IDebtCollectionAccessProxy>();
            var response = accessProxy.GetPeriodList(Request);
            return response;
        }

        [HttpPost]
        [Route("persist")]
        public PersistPeriodListResponse PersistPeriodList([FromBody]PersistPeriodListRequest Request)
        {
            var operation = IOCManager.Resolve<IPersistPeriodListOperation>();

            var response = operation.PersistPeriodList(new PersistPeriodListRequest
            {
                PeriodList = Request.PeriodList
            });

            return response;
        }

    }
}