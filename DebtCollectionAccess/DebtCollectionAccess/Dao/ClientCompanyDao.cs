using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface ICompanyClientDao
    {
        ICollection<CompanyClient> GetAgencyCompanyList(GetCompanyClientListRequest Request, ValidationResults ValidationResults = null);
    }

    public class GetCompanyClientListRequest
    {
        public int CompanyId { get; set; }
    }   

    public class ClientCompanyDao : ICompanyClientDao
    {
        #region Declarations

        private MainContext _DbContext;

        #endregion Declarations

        public ICollection<CompanyClient> GetAgencyCompanyList(GetCompanyClientListRequest Request, ValidationResults ValidationResults = null)
        {
            ICollection<CompanyClient> resultList = null;
            ValidationResults = new ValidationResults();

            try
            {
                using (_DbContext = new MainContext())
                {
                    var query = _DbContext.CompanyClient.AsQueryable();

                    if (Request.CompanyId == 0) return null;
                    query = query.Where(x => x.CompanyId == Request.CompanyId);
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
