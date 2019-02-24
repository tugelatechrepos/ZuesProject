using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalanceManager.Contracts
{
    public class AccountBalance
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal? OpeningBalance { get; set; }
        public decimal? Paid { get; set; }
        public decimal? RemainingBalance { get; set; }
        public int PeriodId { get; set; }
        public decimal? PromisedAmount { get; set; }
        public bool? IsPaymentMissed { get; set; }
        public bool? IsPartialPayment { get; set; }
        public string OwnerName { get; set; }
    }
}