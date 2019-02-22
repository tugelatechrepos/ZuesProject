using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ViewModel
{
    public class AccountBalance
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
        public string OwnerName { get; set; }
    }
}
