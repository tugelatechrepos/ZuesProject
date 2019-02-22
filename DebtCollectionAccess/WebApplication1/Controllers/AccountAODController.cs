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
    [Route("api/accountAOD")]
    public class AccountAODController : Controller
    {
        [HttpPost]
        [Route("list")]
        public GetAccountAODListResponse GetAccountAODList([FromBody]GetAccountAODListRequest Request)
        {
            var dao = IocManager.Resolve<IAccountAODDao>();
            var resultList = dao.GetAccountAODList(Request);

            return new GetAccountAODListResponse { AccountAODList = resultList } ;
        }
    }
}
