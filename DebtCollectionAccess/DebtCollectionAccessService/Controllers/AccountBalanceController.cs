using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using DebtCollectionAccess.Operations;
using Microsoft.AspNetCore.Mvc;
using ProjectCoreLibrary;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/accountBalance")]
    public class AccountBalanceController : Controller
    {
        [HttpPost]
        [Route("list")]
        public GetAccountBalanceListResponse GetAccountBalanceList([FromBody]GetAccountBalanceListRequest Request)
        {
            var operation = IOCManager.Resolve<IGetAccountBalanceListOperation>();
            var response = operation.GetAccountBalanceList(Request);
            return response;
        }

        [HttpPost]
        [Route("persist")]
        public PersistAccountBalanceListResponse PersistAccountBalanceList([FromBody]PersistAccountBalanceListRequest Request)
        {
            var operation = IOCManager.Resolve<IPersistAccountBalanceListOperation>();
            var response = operation.PersistAccountBalanceList(Request);
            return response;
        }
    }
}