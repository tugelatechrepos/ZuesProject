using ProjectCoreLibrary;
using System;
using System.Linq;

namespace DebtCollectionAccess.Dao
{
    public interface ICommissionDao
    {
        Commission GetCommission(decimal Yield, ValidationResults validationResults = null);
    }

    public class CommissionDao : ICommissionDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public Commission GetCommission(decimal Yield, ValidationResults validationResults = null)
        {
            Commission result = null;
            validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    result = _DbContext.Commission.FirstOrDefault(x => Yield >= x.LowerRange && Yield <= x.HigherRange);
                }
            }
            catch (Exception ex)
            {
                validationResults.Add(new ValidationResult
                {
                    ValidationMessage = ex.Message,
                    StackTrace = ex.StackTrace
                });
            }
           
            return result;
        }
    }
}
