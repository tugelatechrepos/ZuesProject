using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetAccountOpeningBalanceListResponse
    {
        public ICollection<AccountOpeningBalance> AccountOpeningBalanceList { get; set; }
    }
}
