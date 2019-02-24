using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetCommissionOperation
    {
        GetCommissionResponse GetCommission(GetCommisionRequest Request);
    }

    public class GetCommissionOperation : IGetCommissionOperation
    {
        #region Declarations

        private GetCommisionRequest _Request;
        private GetCommissionResponse _Response;

        
        public ICommissionDao CommissionDao { get; set; }

        #endregion Declarations

        public GetCommissionResponse GetCommission(GetCommisionRequest Request)
        {
            _Request = Request;
            _Response = new GetCommissionResponse();

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
            _Response.Commission = CommissionDao.GetCommission(Convert.ToDouble(_Request.Yield));
        }
    }
}
