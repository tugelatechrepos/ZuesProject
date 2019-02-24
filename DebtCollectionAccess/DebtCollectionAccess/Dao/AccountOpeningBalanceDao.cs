using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DebtCollectionAccess.Dao
{
    public interface IAccountOpeningBalanceDao
    {
        ICollection<AccountOpeningBalance> GetAccountOpeningBalanceList(GetAccountOpeningBalanceListRequest Request, ValidationResults validationResults = null);

        ValidationResults PersistAccountOpeningBalanceList(PersistAccountOpeningBalanceListRequest Request, ValidationResults validationResults = null);
    }

    public class AccountOpeningBalanceDao : IAccountOpeningBalanceDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ICollection<AccountOpeningBalance> GetAccountOpeningBalanceList(GetAccountOpeningBalanceListRequest Request, ValidationResults validationResults = null)
        {
            ICollection<AccountOpeningBalance> resultList = null;
            validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    var query = _DbContext.AccountOpeningBalance.AsQueryable();
                    query = query.Where(x => x.Period.Id == Request.PeriodId);
                    resultList = query.ToList();
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

            return resultList;
        }

        public ValidationResults PersistAccountOpeningBalanceList(PersistAccountOpeningBalanceListRequest Request, ValidationResults validationResults = null)
        {
            validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    _DbContext.AccountOpeningBalance.UpdateRange(Request.AccountOpeningBalanceList);
                    _DbContext.SaveChanges();
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

            return validationResults;
        }
    }
}
