using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DebtCollectionAccess.Dao
{
    public interface IAccountInceptionDao
    {
        ICollection<AccountInception> GetAccountInceptionList(GetAccountInceptionListRequest Request, ValidationResults validationResults = null);
    }

    public class AccountInceptionDao : IAccountInceptionDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ICollection<AccountInception> GetAccountInceptionList(GetAccountInceptionListRequest Request, ValidationResults validationResults = null)
        {
            ICollection<AccountInception> resultList = null;
            validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    var query = _DbContext.AccountInception.AsQueryable();
                    query = query.Where(x => Request.AccountIdList.Contains(x.AccountId));
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
    }
}
