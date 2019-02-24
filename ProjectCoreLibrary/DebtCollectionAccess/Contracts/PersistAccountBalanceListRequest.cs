using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class PersistAccountBalanceListRequest
    {
        public ICollection<AccountBalance> AccountBalanceList { get; set; }
    }
}
