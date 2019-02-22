using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IServiceTypeDao
    {
        ICollection<ServiceType> GetServiceTypeList();
    }

    [Export(typeof(IServiceTypeDao))]
    public class ServiceTypeDao : IServiceTypeDao
    {
        private DebtCollectionContext _DbContext;

        public ICollection<ServiceType> GetServiceTypeList()
        {
            ICollection<ServiceType> resultList;

            using (_DbContext = new DebtCollectionContext())
            {
                var query = _DbContext.ServiceType.OrderBy(x => x.Id);
                resultList = query.ToList();
            }
            return resultList;
        }
    }
}
