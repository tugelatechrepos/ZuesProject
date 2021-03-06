﻿using DebtCollectionAccess.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace DebtCollectionAccess.Dao
{
    public interface IAccountOwnerDao
    {
        ICollection<AccountOwner> GetAccountOwnerList(GetAccountOwnerListRequest Request);
    }

    public class AccountOwnerDao : IAccountOwnerDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ICollection<AccountOwner> GetAccountOwnerList(GetAccountOwnerListRequest Request)
        {
            ICollection<AccountOwner> resultList = null;

            using (_DbContext = new DebtCollectionContext())
            {
                var query = _DbContext.AccountOwner.AsQueryable();
                query = (Request.AccountIdList != null && Request.AccountIdList.Any()) ? query.Where(x => Request.AccountIdList.Contains(x.AccountId)) : query;
                resultList = query.ToList();
            }
            return resultList;
        }
    }
}
