using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IUserDao
    {
        ICollection<Users> GetUserList(ValidationResults validationResults = null);
    }

    public class UserDao : IUserDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ICollection<Users> GetUserList(ValidationResults validationResults = null)
        {
            ICollection<Users> resultList = null;
            validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    var query = _DbContext.Users.AsQueryable();
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
