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
        private ICollection<AgencyCompany> _AgencyClientList;

        public IAgencyCompanyDao AgencyCompanyDao { get; set; }
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

            var response = AgencyCompanyDao.GetAgencyCompanyList(new GetAgencyCompanyListRequest
            {
                AgencyId = _Request.AgencyId,
            } , _Response.ValidationResults);

            _AgencyClientList = response;
        }

        private void assignCompanyList()
        {
            if (!_Response.ValidationResults.IsValid) return;
            if (_AgencyClientList == null || !_AgencyClientList.Any()) return;

            var clientIdList = _AgencyClientList.Select(x => x.ClientId).ToList();
            _Response.CompanyList = CompanyDao.GetCompanyList(new GetCompanyListRequest
            {
                CompanyIdList = clientIdList
            }, _Response.ValidationResults);
        }
    }
}
