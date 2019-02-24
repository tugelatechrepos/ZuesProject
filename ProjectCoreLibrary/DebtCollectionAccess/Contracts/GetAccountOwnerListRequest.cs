using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetAccountOwnerListRequest
    {
        public ICollection<int> AccountIdList { get; set; }
    }
}
