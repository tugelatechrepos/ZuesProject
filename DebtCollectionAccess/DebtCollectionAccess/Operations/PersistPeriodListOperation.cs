using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IPersistPeriodListOperation
    {
        PersistPeriodListResponse PersistPeriodList(PersistPeriodListRequest Request);
    }

    [Export(typeof(IPersistPeriodListOperation))]
    public class PersistPeriodListOperation : IPersistPeriodListOperation
    {
        #region Declarations
        
        private PersistPeriodListRequest _Request;
        private PersistPeriodListResponse _Response;

        [Import]
        public IPeriodDao PeriodDao { get; set; }

        #endregion Declarations

        public PersistPeriodListResponse PersistPeriodList(PersistPeriodListRequest Request)
        {
            _Request = Request;
            _Response = new PersistPeriodListResponse();

            deletePeriodList();
            persist();

            return _Response;
        }

        private void deletePeriodList()
        {
            var existingPeriodList = PeriodDao.GetPeriodList(new GetPeriodListRequest());
            var existingPeriodIdList = existingPeriodList?.Select(x => x.Id).ToList();
            if (existingPeriodIdList == null || !existingPeriodIdList.Any()) return;

            var PeriodIdList = _Request.PeriodList.Where(x=>x.Id != 0 )?.Select(x => x.Id).ToList();

            if (PeriodIdList == null || !PeriodIdList.Any()) return;

            var IdListToDelete = existingPeriodIdList.Except(PeriodIdList).ToList();

            if (IdListToDelete == null || !IdListToDelete.Any()) return;

            var periodListToDelete = existingPeriodList.Where(x => IdListToDelete.Contains(x.Id)).ToList();
            PeriodDao.DeletePeriodList(periodListToDelete);
        }

        private void persist()
        {
            PeriodDao.PersistPeriodList(_Request.PeriodList);
        }
    }
}
