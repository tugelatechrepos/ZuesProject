using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IPersistPeriodListOperation
    {
        PersistPeriodListResponse PersistPeriodList(PersistPeriodListRequest Request);
    }

    public class PersistPeriodListOperation : IPersistPeriodListOperation
    {
        #region Declarations
        
        private PersistPeriodListRequest _Request;
        private PersistPeriodListResponse _Response;

        public IPeriodDao PeriodDao { get; set; }

        #endregion Declarations

        public PersistPeriodListResponse PersistPeriodList(PersistPeriodListRequest Request)
        {
            _Request = Request;
            _Response = new PersistPeriodListResponse { ValidationResults = new ValidationResults() };

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

           _Response.ValidationResults = PeriodDao.DeletePeriodList(periodListToDelete);
        }

        private void persist()
        {
            if (!_Response.ValidationResults.IsValid) return;

            _Response.ValidationResults = PeriodDao.PersistPeriodList(_Request.PeriodList);
        }
    }
}
