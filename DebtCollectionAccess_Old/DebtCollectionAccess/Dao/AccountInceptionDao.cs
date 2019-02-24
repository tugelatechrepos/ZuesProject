﻿using DebtCollectionAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IAccountInceptionDao
    {
        ICollection<AccountInception> GetAccountInceptionList(GetAccountInceptionListRequest Request);
    }

    [Export(typeof(IAccountInceptionDao))]
    public class AccountInceptionDao : IAccountInceptionDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ICollection<AccountInception> GetAccountInceptionList(GetAccountInceptionListRequest Request)
        {
            ICollection<AccountInception> resultList = null;

            using (_DbContext = new DebtCollectionContext())
            {
               var query =  _DbContext.AccountInception.AsQueryable();

                query = query.Where(x => Request.AccountIdList.Contains(x.AccountId));
                resultList = query.ToList();
            }

            return resultList;
        }
    }
}