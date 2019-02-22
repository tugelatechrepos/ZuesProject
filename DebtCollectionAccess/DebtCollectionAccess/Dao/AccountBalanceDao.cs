using DebtCollectionAccess.Operations;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IAccountBalanceDao
    {
        ICollection<AccountBalance> GetAccountBalanceList(GetAccountBalanceListRequest Request);

        PersistAccountBalanceListResponse persistAccountBalanceList(PersistAccountBalanceListRequest Request);
    }

    public class PersistAccountBalanceListRequest
    {
        public ICollection<AccountBalance> AccountBalanceList { get; set; }
    }

    public class PersistAccountBalanceListResponse
    {

    }

    [Export(typeof(IAccountBalanceDao))]
    public class AccountBalanceDao : IAccountBalanceDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ICollection<AccountBalance> GetAccountBalanceList(GetAccountBalanceListRequest Request)
        {
            ICollection<AccountBalance> resultList;

            using (_DbContext = new DebtCollectionContext())
            {
                var query = _DbContext.AccountBalance.AsQueryable();

                query = (Request.AccountIdList != null && Request.AccountIdList.Any()) ? query.Where(x => Request.AccountIdList.Contains(x.AccountId)) : query;
                query = (Request.PeriodIdList != null && Request.PeriodIdList.Any()) ? query.Where(x => Request.PeriodIdList.Contains(x.Period.Id)) : query;

                resultList = query.ToList();
            }
            return resultList;
        }
        
        public PersistAccountBalanceListResponse persistAccountBalanceList(PersistAccountBalanceListRequest Request)
        {
            using (_DbContext = new DebtCollectionContext())
            {
                _DbContext.AccountBalance.UpdateRange(Request.AccountBalanceList);
                _DbContext.SaveChanges();
            }

            return new PersistAccountBalanceListResponse();
        }
    }
}
