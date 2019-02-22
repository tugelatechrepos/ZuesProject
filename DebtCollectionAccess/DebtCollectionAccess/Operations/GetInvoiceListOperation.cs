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

    public class GetInvoiceListRequest
    {
        public ICollection<int> InvoiceIdList { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }

    public class GetInvoiceListResponse
    {
        public ICollection<Invoice> InvoiceList { get; set; }
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
            _Response.InvoiceList = InvoiceDao.GetInvoiceList(new Dao.GetInvoiceListRequest
            {
                FromDate = _Request.FromDate,
                ToDate = _Request.ToDate,
                InvoiceIdList = _Request.InvoiceIdList
            });
        }
    }
}
