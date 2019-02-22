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
    [Route("api/dataCleanUp")]
    public class DataCleanUpController : Controller
    {
        [HttpGet]
        [Route("delete")]
        public void GetAccountAODList()
        {
            var dao = IocManager.Resolve<IDataCleanUpDao>();
            dao.CleanUpData();
        }
    }
}
