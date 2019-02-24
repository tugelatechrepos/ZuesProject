using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class PaymentHistory
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public long ServiceId { get; set; }
        public string PaymentMode { get; set; }
        public decimal? Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual ServiceType Service { get; set; }        

    }
}
