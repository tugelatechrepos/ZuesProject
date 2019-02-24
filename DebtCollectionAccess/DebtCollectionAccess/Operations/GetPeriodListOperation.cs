using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
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

        public IPeriodDao PeriodDao { get; set; }

        #endregion Declarations

        public GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request)
        {
            _Request = Request;
            _Response = new GetPeriodListResponse { ValidationResults = new ValidationResults() };

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
          _Response.PeriodList = PeriodDao.GetPeriodList(_Request, _Response.ValidationResults);
         
        }
    }
}
