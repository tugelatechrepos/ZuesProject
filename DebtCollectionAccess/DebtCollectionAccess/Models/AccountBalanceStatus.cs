using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class AccountBalanceStatus
    {
        public AccountBalanceStatus()
        {
            AccountBalance = new HashSet<AccountBalance>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AccountBalance> AccountBalance { get; set; }
    }
}
