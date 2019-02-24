using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IDataCleanUpDao
    {
        void CleanUpData();
    }

    [Export(typeof(IDataCleanUpDao))]
    public class DataCleanUpDao : IDataCleanUpDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public void CleanUpData()
        {
            using (_DbContext = new DebtCollectionContext())
            {
                _DbContext.PaymentHistory.RemoveRange(_DbContext.PaymentHistory);
                _DbContext.Invoice.RemoveRange(_DbContext.Invoice);
                _DbContext.AccountOpeningBalance.RemoveRange(_DbContext.AccountOpeningBalance);
                _DbContext.AccountBalance.RemoveRange(_DbContext.AccountBalance);
                _DbContext.Period.RemoveRange(_DbContext.Period);

                _DbContext.SaveChanges();
            }
        }
    }
}
