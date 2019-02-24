using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DebtCollectionAccess.Dao
{
    public interface IAccountAODDao
    {
        ICollection<AccountAod> GetAccountAODList(GetAccountAODListRequest Request,ValidationResults validationResults = null);
    }

    public class AccountAODDao : IAccountAODDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ICollection<AccountAod> GetAccountAODList(GetAccountAODListRequest Request, ValidationResults validationResults = null)
        {
            ICollection<AccountAod> resultList = null;
            validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    var query = _DbContext.AccountAod.AsQueryable();
                    query = (Request.AccountIdList != null && Request.AccountIdList.Any()) ? query.Where(x => Request.AccountIdList.Contains(x.AccountId)) : query;
                    resultList = query.ToList();
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
           
            return resultList;
        }
    }
}
