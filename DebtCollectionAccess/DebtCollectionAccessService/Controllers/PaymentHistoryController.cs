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
using ProjectCoreLibrary;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/paymentHistory")]
    public class PaymentHistoryController : Controller
    {
        [HttpPost]
        [Route("list")]
        public GetPaymentHistoryListResponse GetPaymentHistoryList([FromBody]DebtCollectionAccess.Contracts.GetPaymentHistoryListRequest Request)
        {
            var operation = IOCManager.Resolve<IGetPaymentHistoryListOperation>();
            var response = operation.GetPaymentHistoryList(Request);

            return response;
        }

        [HttpPost]
        [Route("persist")]
        public PersistPaymentHistoryListResponse PersistPaymentHistoryList([FromBody]PersistPaymentHistoryListRequest Request)
        {
            var operation = IOCManager.Resolve<IPaymentHistoryDao>();
            operation.PersistPaymentHistoryList(Request);

            return new PersistPaymentHistoryListResponse();
        }

        [HttpGet]
        [Route("accountlist")]
        public GetAccountIdListResponse GetAccountList()
        {
            var paymentHistoryDao = IOCManager.Resolve<IPaymentHistoryDao>();
            var accountList = paymentHistoryDao.GetAccountIdListFromPaymentHistory();

            var getAccountIdListResponse = new GetAccountIdListResponse { AccountIdList = accountList };
            return getAccountIdListResponse;
        }
    }
}