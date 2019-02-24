using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IPersistAccountBalanceListOperation
    {
        PersistAccountBalanceListResponse PersistAccountBalanceList(PersistAccountBalanceListRequest Request);
    }

    public class PersistAccountBalanceListOperation : IPersistAccountBalanceListOperation
    {
        #region Declarations

        private PersistAccountBalanceListRequest _Request;
        private PersistAccountBalanceListResponse _Response;

        public IAccountBalanceDao AccountBalanceDao { get; set; }

        #endregion Declarations

        public PersistAccountBalanceListResponse PersistAccountBalanceList(PersistAccountBalanceListRequest Request)
        {
            _Request = Request;
            _Response = new PersistAccountBalanceListResponse();

            persist();

            return _Response;
        }

        private void persist()
        {
            _Response.ValidationResults =  AccountBalanceDao.PersistAccountBalanceList(_Request);
        }
    }
}
