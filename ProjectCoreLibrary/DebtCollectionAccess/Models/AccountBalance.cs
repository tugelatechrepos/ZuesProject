
using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class AccountBalance
    {
        public int Id { get; set; }
        public double OpeningBalance { get; set; }
        public double? Paid { get; set; }
        public int? PeriodId { get; set; }
        public double? PromisedAmount { get; set; }
        public double? RemainingBalance { get; set; }
        public int AccountId { get; set; }
        public bool? IsPaymentMissed { get; set; }
        public bool? IsPartialPayment { get; set; }
        public int? Version { get; set; }
        public int? OwnerId { get; set; }

        public virtual Users Owner { get; set; }
        public virtual Period Period { get; set; }
    }
}
