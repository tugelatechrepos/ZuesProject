using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;

using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetInvoiceListOperation
    {
        GetInvoiceListResponse GetInvoiceList(GetInvoiceListRequest Request);
    }


    [Export(typeof(IGetInvoiceListOperation))]
    public class GetInvoiceListOperation : IGetInvoiceListOperation
    {
        #region Declarations

        private GetInvoiceListRequest _Request;
        private GetInvoiceListResponse _Response;

        [Import]
        public IInvoiceDao InvoiceDao { get; set; }

        #endregion Declarations

        public GetInvoiceListResponse GetInvoiceList(GetInvoiceListRequest Request)
        {
            _Request = Request;
            _Response = new GetInvoiceListResponse();

            assignResponse();

            return _Response;
        }

        public void assignResponse()
        {
            _Response.InvoiceList = InvoiceDao.GetInvoiceList(_Request);
        }
    }
}
