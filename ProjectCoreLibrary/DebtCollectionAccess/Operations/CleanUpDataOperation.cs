using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface ICleanUpDataOperation
    {
        void CleanUpData();
    }

    public class CleanUpDataOperation : ICleanUpDataOperation
    {
        #region Declarations

        public IDataCleanUpDao DataCleanUpDao { get; set; }

        #endregion Declarations

        public void CleanUpData()
        {
            DataCleanUpDao.CleanUpData();
        }
    }
}
