using AccountBalanceManagerService.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AccountBalanceManagerService.Controllers
{
    [RoutePrefix("invoicemanager")]
    public class InvoiceController : ApiController
    {
        [HttpGet]
        [ActionName("generate")]
        public GenerateInvoiceProcessorResponse GenerateInvoiceRequest()
        {
            var processor = IocManager.Resolve<IGenerateInvoiceProcessor>();
            var response = processor.GenerateInvoice(new GenerateInvoiceProcessorRequest());
            return response;
        }

        [HttpPost]
        [ActionName("list")]
        public GetInvoiceListResponse GetInvoiceList([FromBody]GetInvoiceListRequest Request)
        {
            var processor = IocManager.Resolve<IInvoiceProcessor>();
            var response = processor.GetInvoiceList(Request);
            return response;
        }
    }
}