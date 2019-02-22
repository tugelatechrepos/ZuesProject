using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetServiceTypeListOperation
    {
        GetGetServiceTypeListResponse GetServiceTypeList();
    }

    
    public class GetGetServiceTypeListResponse 
    {
        public ICollection<ServiceType> ServiceTypeList { get; set; }
    }

    [Export(typeof(IGetServiceTypeListOperation))]
    public class GetServiceTypeListOperation : IGetServiceTypeListOperation
    {
        #region Declarations

        private GetGetServiceTypeListResponse _Response;

        [Import]
        public IServiceTypeDao ServiceTypeDao { get; set; }

        #endregion Declarations

        public GetGetServiceTypeListResponse GetServiceTypeList()
        {
            _Response = new GetGetServiceTypeListResponse();

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
            _Response.ServiceTypeList = ServiceTypeDao.GetServiceTypeList();
        }
    }
}
