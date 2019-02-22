﻿using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IAccountAODDao
    {
        ICollection<AccountAod> GetAccountAODList(GetAccountAODListRequest Request);
    }

    public class GetAccountAODListRequest
    {
       public ICollection<int> AccountIdList { get; set; }
       public ICollection<int> PeriodIdList { get; set; }
    }

    public class GetAccountAODListResponse
    {
        public ICollection<AccountAod> AccountAODList { get; set; }
    }

    [Export(typeof(IAccountAODDao))]
    public class AccountAODDao : IAccountAODDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ICollection<AccountAod> GetAccountAODList(GetAccountAODListRequest Request)
        {
            ICollection<AccountAod> resultList = null;

            using (_DbContext = new DebtCollectionContext())
            {
                var query = _DbContext.AccountAod.AsQueryable();
                query = (Request.AccountIdList != null && Request.AccountIdList.Any()) ? query.Where(x => Request.AccountIdList.Contains(x.AccountId)) : query;
                //query = (Request.PeriodIdList != null && Request.PeriodIdList.Any()) ? query.Where(x => Request.PeriodIdList.Contains(x.PeriodId)) : query;
                //query = query.OrderByDescending(x => x.PeriodId);

                resultList = query.ToList();
            }

            return resultList;
        }
    }
}
