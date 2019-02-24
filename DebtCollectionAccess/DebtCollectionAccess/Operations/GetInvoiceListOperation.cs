using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetInvoiceListOperation
    {
        GetInvoiceListResponse GetInvoiceList(GetInvoiceListRequest Request);
    }

    public class GetInvoiceListOperation : IGetInvoiceListOperation
    {
        #region Declarations

        private GetInvoiceListRequest _Request;
        private GetInvoiceListResponse _Response;

        public IInvoiceDao InvoiceDao { get; set; }

        #endregion Declarations

        public GetInvoiceListResponse GetInvoiceList(GetInvoiceListRequest Request)
        {
            _Request = Request;
            _Response = new GetInvoiceListResponse { ValidationResults = new ValidationResults() };

            assignResponse();

            return _Response;
        }

        public void assignResponse()
        {
           _Response.InvoiceList = InvoiceDao.GetInvoiceList(_Request, _Response.ValidationResults);
       
        }
    }
}
