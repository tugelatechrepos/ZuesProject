using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetAccountAODListResponse
    {
        public ICollection<AccountAod> AccountAODList { get; set; }
    }
}
