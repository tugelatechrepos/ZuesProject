using AccountBalanceManager.Contracts;
using DebtCollectionAccess;
using DebtCollectionAccess.Client;
using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalanceManager.Operations
{
    public interface IGetInvoiceListOperation
    {
        Contracts.GetInvoiceListResponse GetInvoiceList(GetInvoiceListRequest Request);
    }

    public class GetInvoiceListOperation : IGetInvoiceListOperation
    {
        #region Declarations

        private GetInvoiceListRequest _Request;
        private Contracts.GetInvoiceListResponse _Response;
        private ICollection<Invoice> _InvoiceList;

        public IDebtCollectionAccessProxy DebtCollectionAccessProxy { get; set; }

        #endregion Declarations

        public Contracts.GetInvoiceListResponse GetInvoiceList(GetInvoiceListRequest Request)
        {
            _Request = Request;
            _Response = new Contracts.GetInvoiceListResponse { ValidationResults = new ValidationResults() };

            assignInvoiceList();
            assignInvoiceDetailList();

            return _Response;
        }

        private void assignInvoiceList()
        {
            var response = DebtCollectionAccessProxy.GetInvoiceList(_Request);
            _InvoiceList = response.InvoiceList;
            _Response.InvoiceList = _InvoiceList;
        }

        private void assignInvoiceDetailList()
        {
            if (_InvoiceList == null || !_InvoiceList.Any()) return;

            var invoiceDetailList = new List<InvoiceDetail>();

            foreach (var invoice in _InvoiceList)
            {
                var invoiceDetail = Newtonsoft.Json.JsonConvert.DeserializeObject<InvoiceDetail>(invoice.Detail);
                invoiceDetail.InvoiceId = invoice.Id;
                invoiceDetail.GeneratedOn = invoice.GeneratedOn;
                invoiceDetail.PeriodId = invoice.PeriodId;
                invoiceDetailList.Add(invoiceDetail);
            }

            _Response.InvoiceDetailList = invoiceDetailList;
        }
    }
}
