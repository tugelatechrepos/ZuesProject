using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetClientListOperation
    {
        GetClientListResponse GetClientList(GetClientListRequest Request);
    }

    public class GetClientListOperation : IGetClientListOperation
    {
        #region Declarations

        private GetClientListRequest _Request;
        private GetClientListResponse _Response;
        private ICollection<CompanyClient> _CompanyClientList;

        public ICompanyClientDao CompanyClientDao { get; set; }
        public ICompanyDao CompanyDao { get; set; }

        #endregion Declarations

        public GetClientListResponse GetClientList(GetClientListRequest Request)
        {
            _Request = Request;
            _Response = new GetClientListResponse { ValidationResults = new ProjectCoreLibrary.ValidationResults() };

            assignAgencyCompanyList();
            assignCompanyList();

            return _Response;
        }

        private void assignAgencyCompanyList()
        {
            if (!_Response.ValidationResults.IsValid) return;

            var response = CompanyClientDao.GetAgencyCompanyList(new GetCompanyClientListRequest
            {
                CompanyId = _Request.CompanyId,
            } , _Response.ValidationResults);

            _CompanyClientList = response;
        }

        private void assignCompanyList()
        {
            if (!_Response.ValidationResults.IsValid) return;
            if (_CompanyClientList == null || !_CompanyClientList.Any()) return;

            var clientIdList = _CompanyClientList.Select(x => x.ClientId).ToList();
            _Response.CompanyList = CompanyDao.GetCompanyList(new GetCompanyListRequest
            {
                CompanyIdList = clientIdList
            }, _Response.ValidationResults);
        }
    }
}
