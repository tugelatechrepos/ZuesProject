using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class AccountOwner
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int OwnerId { get; set; }

        public virtual Users Owner { get; set; }
    }
}
