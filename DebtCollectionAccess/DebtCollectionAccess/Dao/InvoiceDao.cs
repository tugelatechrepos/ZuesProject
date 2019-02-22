
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IInvoiceDao
    {
        void Persist(Invoice Invoice);

        ICollection<Invoice> GetInvoiceList(GetInvoiceListRequest Request);
    }

    public class GetInvoiceListRequest
    {
        public ICollection<int> InvoiceIdList { get; set; }

        public ICollection<int> PeriodIdList { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }


    [Export(typeof(IInvoiceDao))]
    public class InvoiceDao : IInvoiceDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;
        
        #endregion Declarations

        public void Persist(Invoice Invoice)
        {
            using (_DbContext = new DebtCollectionContext())
            {
                _DbContext.Invoice.Update(Invoice);
                _DbContext.SaveChanges();
            }
        }

        public ICollection<Invoice> GetInvoiceList(GetInvoiceListRequest Request)
        {
            ICollection<Invoice> resultList;

            using (_DbContext = new DebtCollectionContext())
            {
                var query = _DbContext.Invoice.AsQueryable();

                query = (Request.InvoiceIdList != null && Request.InvoiceIdList.Any()) ? query.Where(x => Request.InvoiceIdList.Contains(x.Id)) : query;
                query = (Request.FromDate.HasValue && Request.FromDate.Value != DateTime.MinValue) ? query.Where(x => x.GeneratedOn >= Request.FromDate) : query;
                query = (Request.ToDate.HasValue && Request.ToDate.Value != DateTime.MinValue) ? query.Where(x => x.GeneratedOn <= Request.ToDate) : query;
                query = (Request.PeriodIdList != null && Request.PeriodIdList.Any()) ? query.Where(x => Request.PeriodIdList.Contains(x.PeriodId.Value)) : query;
                query = query.OrderByDescending(x => x.Id);

                resultList = query.ToList();
            }

            return resultList;
        }
    }
}
