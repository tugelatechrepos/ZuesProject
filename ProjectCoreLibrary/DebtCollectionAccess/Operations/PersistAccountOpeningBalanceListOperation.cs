using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IPersistAccountOpeningBalanceListOperation
    {
        PersistAccountOpeningBalanceListResponse PersistAccountOpeningBalanceList(PersistAccountOpeningBalanceListRequest Request);
    }

    public class PersistAccountOpeningBalanceListOperation : IPersistAccountOpeningBalanceListOperation
    {
        #region Declarations

        private PersistAccountOpeningBalanceListRequest _Request;
        private PersistAccountOpeningBalanceListResponse _Response;

        public IAccountOpeningBalanceDao AccountOpeningBalanceDao { get; set; }

        #endregion Declarations

        public PersistAccountOpeningBalanceListResponse PersistAccountOpeningBalanceList(PersistAccountOpeningBalanceListRequest Request)
        {
            _Request = Request;
            _Response = new PersistAccountOpeningBalanceListResponse();

            persist();

            return _Response;
        }

        private void persist()
        {
            _Response = AccountOpeningBalanceDao.PersistAccountOpeningBalanceList(_Request);
        }
    }
}
