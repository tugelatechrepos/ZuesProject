using DebtCollectionAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DebtCollectionAccess.Dao
{

    public interface IPaymentHistoryDao
    {
        ICollection<PaymentHistory> GetPaymentHistoryList(GetPaymentHistoryListRequest Request);

        void PersistPaymentHistoryList(PersistPaymentHistoryListRequest Request);

        ICollection<int> GetAccountIdListFromPaymentHistory();
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

        public ICollection<PaymentHistory> GetPaymentHistoryList(GetPaymentHistoryListRequest Request)
        {
            ICollection<PaymentHistory> resultList = null;

            using (_DbContext = new DebtCollectionContext())
            {
                var query = _DbContext.PaymentHistory.AsQueryable();

                query = (Request.FromDate.HasValue  && Request.FromDate.Value != DateTime.MinValue) ? query.Where(x => x.PaymentDate >= Request.FromDate.Value) : query;
                query = (Request.ToDate.HasValue && Request.ToDate.Value != DateTime.MinValue) ?  query.Where(x => x.PaymentDate <= Request.ToDate.Value) : query;
                query = (Request.AccountIdList != null && Request.AccountIdList.Any()) ? query.Where(x => Request.AccountIdList.Contains(x.AccountId)) : query;
                query = Request.InvoiceId.HasValue ? query.Where(x => x.Invoice.Id == Request.InvoiceId.Value) : query;
                query = Request.Take > 0 ? query.Skip(Request.Skip).Take(Request.Take) : query ;
                query = query.OrderBy(x => x.PaymentDate);
              
                resultList = query.ToList();
            }

            return resultList;
        }

        public void PersistPaymentHistoryList(PersistPaymentHistoryListRequest Request)
        {
            using (_DbContext = new DebtCollectionContext())
            {
                _DbContext.PaymentHistory.UpdateRange(Request.PaymentHistoryList);
                _DbContext.SaveChanges();
            }
        }

        public ICollection<int> GetAccountIdListFromPaymentHistory()
        {
            ICollection<int> resultList = null;

            using (_DbContext = new DebtCollectionContext())
            {
                var query = _DbContext.PaymentHistory.Select(x => x.AccountId)?.Distinct();
                resultList = query?.ToList();
            }
            return resultList;
        }
    }
}
