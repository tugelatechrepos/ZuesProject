using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class AccountAod
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal? Amount { get; set; }
    }
}
