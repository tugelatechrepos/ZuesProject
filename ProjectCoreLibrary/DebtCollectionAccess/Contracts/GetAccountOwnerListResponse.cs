using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetAccountOwnerListResponse
    {
        public ICollection<AccountOwner> AccountOwnerList { get; set; }
    }
}
