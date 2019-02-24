using System;
using System.Collections.Generic;
using DebtCollectionAccess;
using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectCoreLibrary;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/invoice")]
    public class InvoiceController : Controller
    {
        [HttpPost]
        [Route("persist")]
        public PersistInvoiceResponse PersistInvoice([FromBody]PersistInvoiceRequest Request)
        {
            var operation = IOCManager.Resolve<IPersistInvoiceOperation>();
            var response = operation.PersistInvoice(Request);
            return response;
        }

        [HttpPost]
        [Route("list")]
        public GetInvoiceListResponse GetInvoiceList([FromBody]GetInvoiceListRequest Request)
        {
            var operation = IOCManager.Resolve<IGetInvoiceListOperation>();
            var response = operation.GetInvoiceList(Request);          
            return response;
        }
    }
}
