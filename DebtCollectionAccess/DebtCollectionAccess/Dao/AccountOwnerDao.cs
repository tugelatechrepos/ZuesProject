using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IAccountOwnerDao
    {
        ICollection<AccountOwner> GetAccountOwnerList(GetAccountOwnerListRequest Request);
    }

    public class GetAccountOwnerListRequest
    {
        public ICollection<int> AccountIdList { get; set; }
    }

    public class GetAccountOwnerListResponse
    {
        public ICollection<AccountOwner> AccountOwnerList { get; set; }
    }

    [Export(typeof(IAccountOwnerDao))]
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
