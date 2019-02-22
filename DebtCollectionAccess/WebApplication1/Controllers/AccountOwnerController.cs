using DebtCollectionAccess;
using DebtCollectionAccess.Dao;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/accountOwner")]
    public class AccountOwnerController : Controller
    {
        [HttpPost]
        [Route("list")]
        public GetAccountOwnerListResponse GetAccountOwnerList([FromBody]GetAccountOwnerListRequest Request)
        {
            var response = new GetAccountOwnerListResponse();
            var dao = IocManager.Resolve<IAccountOwnerDao>();
            var daoResponse = dao.GetAccountOwnerList(Request);
            response.AccountOwnerList = daoResponse;
            return response;
        }
    }
}
