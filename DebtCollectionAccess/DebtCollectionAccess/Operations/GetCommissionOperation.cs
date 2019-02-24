using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetCommissionOperation
    {
        GetCommissionResponse GetCommission(GetCommissionRequest Request);
    }

    public class GetCommissionOperation : IGetCommissionOperation
    {
        #region Declarations

        private GetCommissionRequest _Request;
        private GetCommissionResponse _Response;

        
        public ICommissionDao CommissionDao { get; set; }

        #endregion Declarations

        public GetCommissionResponse GetCommission(GetCommissionRequest Request)
        {
            _Request = Request;
            _Response = new GetCommissionResponse { ValidationResults = new ValidationResults() };

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
             _Response.Commission = CommissionDao.GetCommission(_Request.Yield , _Response.ValidationResults);           
        }
    }
}
