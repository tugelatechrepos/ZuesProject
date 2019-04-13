using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class AccountOpeningBalance
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal OpeningBalance { get; set; }
        public int PeriodId { get; set; }

        public virtual Period Period { get; set; }
    }
}
