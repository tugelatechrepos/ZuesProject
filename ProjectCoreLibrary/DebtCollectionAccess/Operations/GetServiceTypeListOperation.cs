using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
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

    public class GetServiceTypeListOperation : IGetServiceTypeListOperation
    {
        #region Declarations

        private GetGetServiceTypeListResponse _Response;

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
