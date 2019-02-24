using System.Linq;

namespace DebtCollectionAccess.Dao
{
    public interface ICommissionDao
    {
        Commission GetCommission(double Yield);
    }

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
