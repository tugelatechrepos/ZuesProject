using DebtCollectionAccess.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace DebtCollectionAccess.Dao
{
    public interface IAccountOpeningBalanceDao
    {
        ICollection<AccountOpeningBalance> GetAccountOpeningBalanceList(GetAccountOpeningBalanceListRequest Request);

        PersistAccountOpeningBalanceListResponse PersistAccountOpeningBalanceList(PersistAccountOpeningBalanceListRequest Request);
    }

    public class AccountOpeningBalanceDao : IAccountOpeningBalanceDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ICollection<AccountOpeningBalance> GetAccountOpeningBalanceList(GetAccountOpeningBalanceListRequest Request)
        {
            ICollection<AccountOpeningBalance> resultList = null;

            using (_DbContext = new DebtCollectionContext())
            {
                var query = _DbContext.AccountOpeningBalance.AsQueryable();
                query = query.Where(x => x.Period.Id == Request.PeriodId);
                resultList = query.ToList();
            }

            return resultList;
        }

        public PersistAccountOpeningBalanceListResponse PersistAccountOpeningBalanceList(PersistAccountOpeningBalanceListRequest Request)
        {
            var response = new PersistAccountOpeningBalanceListResponse();

            using (_DbContext = new DebtCollectionContext())
            {
                _DbContext.AccountOpeningBalance.UpdateRange(Request.AccountOpeningBalanceList);
                _DbContext.SaveChanges();
            }

            return response;
        }
    }
}
