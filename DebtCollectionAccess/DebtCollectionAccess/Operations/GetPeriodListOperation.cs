using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetPeriodListOperation
    {
        GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request);
    }

    [Export(typeof(IGetPeriodListOperation))]
    public class GetPeriodListOperation : IGetPeriodListOperation
    {
        #region Declarations

        private GetPeriodListRequest _Request;
        private GetPeriodListResponse _Response;

        [Import]
        public IPeriodDao PeriodDao { get; set; }

        #endregion Declarations

        public GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request)
        {
            _Request = Request;
            _Response = new GetPeriodListResponse();

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
            _Response.PeriodList = PeriodDao.GetPeriodList(_Request);
        }
    }
}
