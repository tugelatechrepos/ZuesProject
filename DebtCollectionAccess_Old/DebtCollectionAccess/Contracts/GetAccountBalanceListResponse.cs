using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetAccountBalanceListResponse
    {
        public ICollection<AccountBalance> AccountBalanceList { get; set; }
    }
}
