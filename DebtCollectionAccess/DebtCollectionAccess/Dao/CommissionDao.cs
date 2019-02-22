using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface ICommissionDao
    {
        Commission GetCommission(double Yield);
    }

    [Export(typeof(ICommissionDao))]
    public class CommissionDao : ICommissionDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public Commission GetCommission(double Yield)
        {
            Commission result = null;

            using (_DbContext = new DebtCollectionContext())
            {
                result = _DbContext.Commission.FirstOrDefault(x => Yield >= x.LowerRange && Yield <= x.HigherRange);                
            }

            return result;
        }
    }
}
