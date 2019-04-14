using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DebtCollectionAccess.Dao
{
    public interface IAccountBalanceDao
    {
        ICollection<AccountBalance> GetAccountBalanceList(GetAccountBalanceListRequest Request, ValidationResults validationResults = null);

        ValidationResults PersistAccountBalanceList(PersistAccountBalanceListRequest Request, ValidationResults validationResults = null);
    }

    public class AccountBalanceDao : IAccountBalanceDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ICollection<AccountBalance> GetAccountBalanceList(GetAccountBalanceListRequest Request, ValidationResults validationResults = null)
        {
            ICollection<AccountBalance> resultList = null;
            validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    var query = _DbContext.AccountBalance.AsQueryable();

                    query = query.Where(x => x.CompanyId == Request.CompanyId);
                    query = (Request.AccountIdList != null && Request.AccountIdList.Any()) ? query.Where(x => Request.AccountIdList.Contains(x.AccountId)) : query;
                    query = (Request.PeriodIdList != null && Request.PeriodIdList.Any()) ? query.Where(x => Request.PeriodIdList.Contains(x.Period.Id)) : query;
                    query = query.Where(x => Request.StatusIdList.Contains(x.StatusId));

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

        public ValidationResults PersistAccountBalanceList(PersistAccountBalanceListRequest Request, ValidationResults validationResults = null)
        {
            validationResults = new ValidationResults();
            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    _DbContext.AccountBalance.UpdateRange(Request.AccountBalanceList);
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
