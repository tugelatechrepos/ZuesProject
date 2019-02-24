using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalanceManager.Contracts
{
    public class PaymentHistory
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public long ServiceId { get; set; }
        public string PaymentMode { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? InvoiceId { get; set; }
        public string ServiceName { get; set; }
    }
}