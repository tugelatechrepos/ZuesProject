using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class AccountBalance
    {
        public int Id { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal? Paid { get; set; }
        public int? PeriodId { get; set; }
        public decimal? PromisedAmount { get; set; }
        public decimal? RemainingBalance { get; set; }
        public int AccountId { get; set; }
        public bool? IsPaymentMissed { get; set; }
        public bool? IsPartialPayment { get; set; }
        public int? Version { get; set; }
        public int? OwnerId { get; set; }
        public int? CompanyId { get; set; }
        public int StatusId { get; set; }

        public virtual Users Owner { get; set; }
        public virtual Period Period { get; set; }
        public virtual AccountBalanceStatus Status { get; set; }
    }
}
