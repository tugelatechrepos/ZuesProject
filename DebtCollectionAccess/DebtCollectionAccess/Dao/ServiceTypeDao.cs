using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IServiceTypeDao
    {
        ICollection<ServiceType> GetServiceTypeList(ValidationResults validationResults = null);
    }

    public class ServiceTypeDao : IServiceTypeDao
    {
        private DebtCollectionContext _DbContext;

        public ICollection<ServiceType> GetServiceTypeList(ValidationResults validationResults = null)
        {
            ICollection<ServiceType> resultList = null;
            validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    var query = _DbContext.ServiceType.OrderBy(x => x.Id);
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
