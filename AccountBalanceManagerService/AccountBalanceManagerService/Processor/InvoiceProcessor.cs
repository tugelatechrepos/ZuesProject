using AccountBalanceManagerService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Processor
{
    public interface IInvoiceProcessor
    {
        GetInvoiceListResponse GetInvoiceList(GetInvoiceListRequest Request);

        PersistInvoiceResponse PersistInvoice(PersistInvoiceRequest Request);
    }

    public class GetInvoiceListRequest
    {
        public ICollection<int> InvoiceIdList { get; set; }

        public ICollection<int> PeriodIdList { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }

    public class GetInvoiceListResponse
    {
        public ICollection<Invoice> InvoiceList { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetailList { get; set; }
    }

    public class PersistInvoiceRequest
    {
        public Invoice Invoice { get; set; }
    }

    public class PersistInvoiceResponse
    {
        public int InvoiceId { get; set; }
    }

    
    public class InvoiceProcessor : IInvoiceProcessor
    {
        #region Declarations

        private GetInvoiceListRequest _Request;
        private GetInvoiceListResponse _Response;
        private ICollection<Invoice> _InvoiceList;
        private ICollection<InvoiceDetail> _InvoiceDetailList;

       
        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetInvoiceListResponse GetInvoiceList(GetInvoiceListRequest Request)
        {
            _Request = Request;
            _Response = new GetInvoiceListResponse();

            assignInvoiceList();
            assignInvoiceDetailList();

            _Response.InvoiceDetailList = _InvoiceDetailList;

            return _Response;
        }

        public PersistInvoiceResponse PersistInvoice(PersistInvoiceRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = "invoice/persist",
                RequestBody = Request
            });

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<PersistInvoiceResponse>(daoResponse.data);

            return response;
        }

        private void assignInvoiceList()
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = "invoice/list",
                RequestBody = _Request
            });

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetInvoiceListResponse>(daoResponse.data);

            _InvoiceList = response.InvoiceList;
        }

        private void assignInvoiceDetailList()
        {
            if (_InvoiceList == null || !_InvoiceList.Any()) return;

            var invoiceDetailListString = _InvoiceList.Select(x => x.Detail);
            _InvoiceDetailList = new List<InvoiceDetail>();

            foreach(var invoice in _InvoiceList)
            {
                var invoiceDetail = Newtonsoft.Json.JsonConvert.DeserializeObject<InvoiceDetail>(invoice.Detail);
                invoiceDetail.InvoiceId = invoice.Id;
                invoiceDetail.GeneratedOn = invoice.GeneratedOn;
                invoiceDetail.PeriodId = invoice.PeriodId;
                _InvoiceDetailList.Add(invoiceDetail);
            }          
        }
    }
}