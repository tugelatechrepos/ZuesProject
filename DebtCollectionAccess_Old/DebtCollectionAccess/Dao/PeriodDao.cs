using DebtCollectionAccess.Contracts;

using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IPeriodDao
    {
        ICollection<Period> GetPeriodList(GetPeriodListRequest Request);

        void PersistPeriodList(ICollection<Period> PeriodList);

        void DeletePeriodList(ICollection<Period> PeriodList);

        Period GetPeriodById(int Id);
    }

    [Export(typeof(IPeriodDao))]
    public class PeriodDao : IPeriodDao
    {
        private DebtCollectionContext _DbContext;

        public ICollection<Period> GetPeriodList(GetPeriodListRequest Request)
        {
            ICollection<Period> resultList = null;

            using (_DbContext = new DebtCollectionContext())
            {
                var query = _DbContext.Period.AsQueryable();
                query = (Request.PeriodIdList != null && Request.PeriodIdList.Any()) ? query.Where(x => Request.PeriodIdList.Contains(x.Id)) : query;
                query = query.OrderByDescending(x => x.FromDate);
                resultList = query.ToList();
            }

            return resultList;
        }

        public void PersistPeriodList(ICollection<Period> PeriodList)
        {
            using (_DbContext = new DebtCollectionContext())
            {
                _DbContext.UpdateRange(PeriodList);
                _DbContext.SaveChanges();
            }
        }

        public void DeletePeriodList(ICollection<Period> PeriodList)
        {
            using (_DbContext = new DebtCollectionContext())
            {
                _DbContext.RemoveRange(PeriodList);
                _DbContext.SaveChanges();
            }
        }

        public Period GetPeriodById(int Id)
        {
            Period result;
            using (_DbContext = new DebtCollectionContext())
            {
                result = _DbContext.Period.FirstOrDefault(x => x.Id == Id);
            }
            return result;
        }

    }
}
