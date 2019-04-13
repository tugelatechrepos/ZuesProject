using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class Invoice
    {
        public Invoice()
        {
            PaymentHistory = new HashSet<PaymentHistory>();
        }

        public int Id { get; set; }
        public string Detail { get; set; }
        public DateTime GeneratedOn { get; set; }
        public int? PeriodId { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Period Period { get; set; }
        public virtual ICollection<PaymentHistory> PaymentHistory { get; set; }
    }
}
