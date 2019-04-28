using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Models;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DebtCollectionAccess.Dao
{
    public interface IPeriodDao
    {
        ICollection<Period> GetPeriodList(GetPeriodListRequest Request, ValidationResults validationResults = null);

        ValidationResults PersistPeriodList(ICollection<Period> PeriodList, ValidationResults validationResults = null);

        ValidationResults DeletePeriodList(ICollection<Period> PeriodList, ValidationResults validationResults = null);

        Period GetPeriodById(int Id, ValidationResults validationResults = null);
    }

    public class PeriodDao : IPeriodDao
    {
        private DebtCollectionContext _DbContext;

        public ICollection<Period> GetPeriodList(GetPeriodListRequest Request, ValidationResults validationResults = null)
        {
            ICollection<Period> resultList = null;
            validationResults = new ValidationResults();

            try
            {
                using (var dbContext =  DebtCollectionDBFactory.GetDBContext(Request.CompanyId))
                {
                    var query = dbContext.Period.AsQueryable();

                    query = Request.CompanyId != 0 ? query.Where(x => x.CompanyId == Request.CompanyId) : query;
                    query = (Request.PeriodIdList != null && Request.PeriodIdList.Any()) ? query.Where(x => Request.PeriodIdList.Contains(x.Id)) : query;

                    if (Request.CompanyId == 0 && (Request.PeriodIdList == null || !Request.PeriodIdList.Any())) return null;
                    query = query.OrderByDescending(x => x.FromDate);
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

        public ValidationResults PersistPeriodList(ICollection<Period> PeriodList, ValidationResults validationResults = null)
        {
            validationResults = new ValidationResults();
            
            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    _DbContext.UpdateRange(PeriodList);
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

        public ValidationResults DeletePeriodList(ICollection<Period> PeriodList, ValidationResults validationResults = null)
        {
            validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    _DbContext.RemoveRange(PeriodList);
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

        public Period GetPeriodById(int Id, ValidationResults validationResults = null)
        {
            Period result = null;
            validationResults = new ValidationResults();

            try
            {
                using (_DbContext = new DebtCollectionContext())
                {
                    result = _DbContext.Period.FirstOrDefault(x => x.Id == Id);
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

            return result;
        }

    }
}
