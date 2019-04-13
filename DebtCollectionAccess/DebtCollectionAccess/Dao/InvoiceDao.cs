using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DebtCollectionAccess.Dao
{
    public interface IInvoiceDao
    {
        ValidationResults Persist(Invoice Invoice , ValidationResults validationResults = null);

        ICollection<Invoice> GetInvoiceList(GetInvoiceListRequest Request , ValidationResults validationResults = null);
    }

    public class InvoiceDao : IInvoiceDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;
        
        #endregion Declarations

        public ValidationResults Persist(Invoice Invoice, ValidationResults validationResults = null)
        {
            validationResults = new ValidationResults();
            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    _DbContext.Invoice.Update(Invoice);
                    _DbContext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                validationResults.Add(new ValidationResult
                {
                    ValidationMessage = ex.Message,
                    StackTrace = ex.StackTrace
                });
            }
            return validationResults;
        }

        public ICollection<Invoice> GetInvoiceList(GetInvoiceListRequest Request, ValidationResults validationResults = null)
        {
            ICollection<Invoice> resultList = null;
            validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    var query = _DbContext.Invoice.AsQueryable();

                    query = query.Where(x => x.CompanyId == Request.CompanyId);
                    query = (Request.InvoiceIdList != null && Request.InvoiceIdList.Any()) ? query.Where(x => Request.InvoiceIdList.Contains(x.Id)) : query;
                    query = (Request.FromDate.HasValue && Request.FromDate.Value != DateTime.MinValue) ? query.Where(x => x.GeneratedOn >= Request.FromDate) : query;
                    query = (Request.ToDate.HasValue && Request.ToDate.Value != DateTime.MinValue) ? query.Where(x => x.GeneratedOn <= Request.ToDate) : query;
                    query = (Request.PeriodIdList != null && Request.PeriodIdList.Any()) ? query.Where(x => Request.PeriodIdList.Contains(x.PeriodId.Value)) : query;
                    query = query.OrderByDescending(x => x.Id);

                    resultList = query.ToList();
                }

            }
            catch (Exception ex)
            {
                validationResults.Add(new ValidationResult
                {
                    ValidationMessage = ex.Message,
                    StackTrace = ex.StackTrace
                });
            }
         
            return resultList;
        }
    }
}
