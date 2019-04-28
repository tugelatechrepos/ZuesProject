using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface ICompanyDao
    {
        ICollection<Company> GetCompanyList(GetCompanyListRequest Request , ValidationResults ValidationResults = null);
    }

    public class CompanyDao : ICompanyDao
    {
        #region Declarations

        private MainContext _DbContext;

        #endregion Declarations

        public ICollection<Company> GetCompanyList(GetCompanyListRequest Request, ValidationResults ValidationResults = null)
        {
            ICollection<Company> resultList = null;
            ValidationResults = new ValidationResults();

            try
            {
                using (_DbContext = new MainContext())
                {
                    var query = _DbContext.Company.AsQueryable();

                    if (Request.CompanyIdList == null) return null;
                    query = query.Where(x => Request.CompanyIdList.Contains(x.Id));
                    resultList = query.ToList();
                }
            }
            catch (Exception ex)
            {
                ValidationResults.Add(new ValidationResult
                {
                    ValidationMessage = ex.Message,
                    StackTrace = ex.StackTrace
                });
            }

            return resultList;
        }
    }
}
