using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DebtCollectionAccess.Dao
{

    public interface IPaymentHistoryDao
    {
        ICollection<PaymentHistory> GetPaymentHistoryList(GetPaymentHistoryListRequest Request, ValidationResults validationResults = null);

        ValidationResults PersistPaymentHistoryList(PersistPaymentHistoryListRequest Request, ValidationResults validationResults = null);

        ICollection<int> GetAccountIdListFromPaymentHistory(ValidationResults validationResults = null);
    }

    public class GetPaymentHistoryListRequest
    {
        public ICollection<int> AccountIdList { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? InvoiceId { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }

    public class PaymentHistoryDao : IPaymentHistoryDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ICollection<PaymentHistory> GetPaymentHistoryList(GetPaymentHistoryListRequest Request, ValidationResults validationResults = null)
        {
            ICollection<PaymentHistory> resultList = null;
            validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    var query = _DbContext.PaymentHistory.AsQueryable();

                    query = (Request.FromDate.HasValue && Request.FromDate.Value != DateTime.MinValue) ? query.Where(x => x.PaymentDate >= Request.FromDate.Value) : query;
                    query = (Request.ToDate.HasValue && Request.ToDate.Value != DateTime.MinValue) ? query.Where(x => x.PaymentDate <= Request.ToDate.Value) : query;
                    query = (Request.AccountIdList != null && Request.AccountIdList.Any()) ? query.Where(x => Request.AccountIdList.Contains(x.AccountId)) : query;
                    query = Request.InvoiceId.HasValue ? query.Where(x => x.Invoice.Id == Request.InvoiceId.Value) : query;
                    query = Request.Take > 0 ? query.Skip(Request.Skip).Take(Request.Take) : query;
                    query = query.OrderBy(x => x.PaymentDate);

                    resultList = query.ToList();
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

            return resultList;
        }

        public ValidationResults PersistPaymentHistoryList(PersistPaymentHistoryListRequest Request, ValidationResults validationResults = null)
        {
            validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    _DbContext.PaymentHistory.UpdateRange(Request.PaymentHistoryList);
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

        public ICollection<int> GetAccountIdListFromPaymentHistory(ValidationResults validationResults = null)
        {
            ICollection<int> resultList = null;
            validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    var query = _DbContext.PaymentHistory.Select(x => x.AccountId)?.Distinct();
                    resultList = query?.ToList();
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
          
            return resultList;
        }
    }
}
