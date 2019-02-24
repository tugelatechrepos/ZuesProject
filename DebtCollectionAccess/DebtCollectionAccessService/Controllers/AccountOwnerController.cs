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
    [Route("api/accountOwner")]
    public class AccountOwnerController : Controller
    {
        [HttpPost]
        [Route("list")]
        public GetAccountOwnerListResponse GetAccountOwnerList([FromBody]GetAccountOwnerListRequest Request)
        {
            var response = new GetAccountOwnerListResponse();
            var dao = IOCManager.Resolve<IAccountOwnerDao>();
            var daoResponse = dao.GetAccountOwnerList(Request);
            response.AccountOwnerList = daoResponse;
            return response;
        }
    }
}
