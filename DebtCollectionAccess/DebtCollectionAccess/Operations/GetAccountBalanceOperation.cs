﻿using DebtCollectionAccess.Dao;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IGetAccountBalanceOperation
    {
        GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request);
    }

    public class GetAccountBalanceListRequest
    {
        public ICollection<int> AccountIdList { get; set; }
        public ICollection<int> PeriodIdList { get; set; }
    }

    public class GetAccountBalanceListResponse
    {
        public ICollection<AccountBalance> AccountBalanceList { get; set; }
    }



    [Export(typeof(IGetAccountBalanceOperation))]
    public class GetAccountBalanceOperation : IGetAccountBalanceOperation
    {
        #region Declarations

        private GetAccountBalanceListRequest _Request;
        private GetAccountBalanceListResponse _Response;

        [Import]
        public IAccountBalanceDao AccountBalanceDao { get; set; }
        
        #endregion Declarations

        public GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request)
        {
            _Request = Request;
            _Response = new GetAccountBalanceListResponse();

            assignResponse();

            return _Response;
        }

        private void assignResponse()
        {
            _Response.AccountBalanceList = AccountBalanceDao.GetAccountBalanceList(_Request);
        }
    }
}
