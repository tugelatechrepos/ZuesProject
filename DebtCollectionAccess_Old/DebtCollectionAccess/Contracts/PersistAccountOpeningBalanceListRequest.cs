using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class PersistAccountOpeningBalanceListRequest
    {
        public ICollection<AccountOpeningBalance> AccountOpeningBalanceList { get; set; }
    }
}
