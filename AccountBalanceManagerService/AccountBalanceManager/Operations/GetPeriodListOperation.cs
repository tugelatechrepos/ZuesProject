using AccountBalanceManager.Contracts;
using DebtCollectionAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalanceManager.Operations
{
    public interface IGetPeriodListOperation
    {
        GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request);
    }

    public class GetPeriodListOperation : IGetPeriodListOperation
    {
        #region Declarations

        private GetPeriodListRequest _Request;
        private GetPeriodListResponse _Response;      

        public IDebtCollectionAccessProxy DebtCollectionAccessProxy { get; set; }

        #endregion Declarations

        public GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request)
        {
            _Request = Request;
            _Response = new GetPeriodListResponse { ValidationResults = new ProjectCoreLibrary.ValidationResults() };

            assignPeriodList();

            return _Response;
        }

        private void assignPeriodList()
        {
            if (!_Response.ValidationResults.IsValid) return;

            var response = DebtCollectionAccessProxy.GetPeriodList(new DebtCollectionAccess.Contracts.GetPeriodListRequest
            {
                CompanyId = _Request.CompanyId,
                PeriodIdList = _Request.PeriodIdList
            });

            _Response.PeriodList = response.PeriodList;
        }
    }
}
