
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IAccountOpeningBalanceDao
    {
        ICollection<AccountOpeningBalance> GetAccountOpeningBalanceList(GetAccountOpeningBalanceListRequest Request);

        PersistAccountOpeningBalanceListResponse PersistAccountOpeningBalanceList(PersistAccountOpeningBalanceListRequest Request);
    }

    public class GetAccountOpeningBalanceListRequest
    {
        public int PeriodId { get; set; }
    }

    public class GetAccountOpeningBalanceListResponse
    {
        public ICollection<AccountOpeningBalance> AccountOpeningBalanceList { get; set; }
    }

    public class PersistAccountOpeningBalanceListRequest
    {
        public ICollection<AccountOpeningBalance> AccountOpeningBalanceList { get; set; }
    }

    public class PersistAccountOpeningBalanceListResponse
    {

    }

    [Export(typeof(IAccountOpeningBalanceDao))]
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
