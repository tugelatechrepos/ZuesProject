using DebtCollectionAccess;
using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using Microsoft.AspNetCore.Mvc;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/accountInception")]
    public class AccountInceptionController : Controller
    {
        [HttpPost]
        [Route("list")]
        public GetAccountInceptionListResponse GetAccountInceptionList([FromBody]GetAccountInceptionListRequest Request)
        {
            var dao = IOCManager.Resolve<IAccountInceptionDao>();
            var resultList = dao.GetAccountInceptionList(Request);

            return new GetAccountInceptionListResponse { AccountInceptionList = resultList };
        }
    }
}
