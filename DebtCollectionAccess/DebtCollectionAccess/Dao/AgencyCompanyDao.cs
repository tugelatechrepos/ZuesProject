using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IAgencyCompanyDao
    {
        ICollection<AgencyCompany> GetAgencyCompanyList(GetAgencyCompanyListRequest Request, ValidationResults ValidationResults = null);
    }

    public class GetAgencyCompanyListRequest
    {
        public int AgencyId { get; set; }
    }   

    public class AgencyCompanyDao : IAgencyCompanyDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ICollection<AgencyCompany> GetAgencyCompanyList(GetAgencyCompanyListRequest Request, ValidationResults ValidationResults = null)
        {
            ICollection<AgencyCompany> resultList = null;
            ValidationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    var query = _DbContext.AgencyCompany.AsQueryable();

                    if (Request.AgencyId == 0) return null;
                    query = query.Where(x => x.AgencyId == Request.AgencyId);
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
