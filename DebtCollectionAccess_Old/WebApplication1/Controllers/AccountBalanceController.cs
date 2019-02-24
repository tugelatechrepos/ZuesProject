using System;
using System.Collections.Generic;
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
    [Route("api/accountBalance")]
    public class AccountBalanceController : Controller
    {
        [HttpPost]
        [Route("list")]
        public GetAccountBalanceListResponse GetAccountBalanceList([FromBody]GetAccountBalanceListRequest Request)
        {
            var operation = IocManager.Resolve<IGetAccountBalanceOperation>();
            var response = operation.GetAccountBalanceList(Request);
            return response;
        }

        [HttpPost]
        [Route("persist")]
        public PersistAccountBalanceListResponse PersistAccountBalanceList([FromBody]PersistAccountBalanceListRequest Request)
        {
            var dao = IocManager.Resolve<IAccountBalanceDao>();
            var response = dao.persistAccountBalanceList(Request);
            return response;
        }
    }
}