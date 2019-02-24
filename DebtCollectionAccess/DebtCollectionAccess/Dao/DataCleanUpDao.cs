using ProjectCoreLibrary;
using System;

namespace DebtCollectionAccess.Dao
{
    public interface IDataCleanUpDao
    {
        ValidationResults CleanUpData(ValidationResults validationResults = null);
    }

    public class DataCleanUpDao : IDataCleanUpDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ValidationResults CleanUpData(ValidationResults validationResults = null)
        {
            validationResults = new ValidationResults();
            try
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
            catch(Exception ex)
            {
                validationResults.Add(new ValidationResult
                {
                    ValidationMessage = ex.Message,
                    StackTrace = ex.StackTrace
                });
            }

            return validationResults;
        }
         
    }
}
