using DebtCollectionAccess;
using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using DebtCollectionAccess.Operations;
using Microsoft.AspNetCore.Mvc;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/accountOpeningBalance")]
    public class AccountOpeningBalanceController : Controller
    {
        [HttpPost]
        [Route("list")]
        public GetAccountOpeningBalanceListResponse GetAccountOpeningBalanceList([FromBody]GetAccountOpeningBalanceListRequest Request)
        {
            var dao = IOCManager.Resolve<IAccountOpeningBalanceDao>();
            var resultList = dao.GetAccountOpeningBalanceList(Request);
            return new GetAccountOpeningBalanceListResponse { AccountOpeningBalanceList = resultList };
        }

        [HttpPost]
        [Route("persist")]
        public PersistAccountOpeningBalanceListResponse PersistAccountOpeningBalanceList([FromBody]PersistAccountOpeningBalanceListRequest Request)
        {
            var operation = IOCManager.Resolve<IPersistAccountOpeningBalanceListOperation>();
            var response = operation.PersistAccountOpeningBalanceList(Request);
            return response;
        }
    }
}
