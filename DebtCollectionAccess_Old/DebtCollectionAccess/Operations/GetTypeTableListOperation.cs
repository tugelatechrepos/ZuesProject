using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetTypeTableListOperation
    {
        GetTypeTableListResponse GetTypeTableList(GetTypeTableListRequest Request);
    }

    [Export(typeof(IGetTypeTableListOperation))]
    public class GetTypeTableListOperation : IGetTypeTableListOperation
    {
        #region Declarations

        private GetTypeTableListRequest _Request;
        private GetTypeTableListResponse _Response;

        [Import]
        public IServiceTypeDao ServiceTypeDao { get; set; }

        [Import]
        public IUserDao UserDao { get; set; }

        #endregion Declarations

        public GetTypeTableListResponse GetTypeTableList(GetTypeTableListRequest Request)
        {
            _Request = Request;
            _Response = new GetTypeTableListResponse();

            assignServiceTypeList();
            assignUserList();

            return _Response;
        }

        private void assignServiceTypeList()
        {
            if (!_Request.IncludeServiceTypeList) return;

            _Response.ServiceTypeList =  ServiceTypeDao.GetServiceTypeList();
        }

        private void assignUserList()
        {
            if (!_Request.IncludeUserList) return;

            _Response.UserList = UserDao.GetUserList();
        }
    }
}
