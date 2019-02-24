using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            PaymentHistory = new HashSet<PaymentHistory>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PaymentHistory> PaymentHistory { get; set; }
    }
}
