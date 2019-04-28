using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class PaymentHistoryPayloadPeriod
    {
        public PaymentHistoryPayloadPeriod()
        {
            PaymentHistoryPayload = new HashSet<PaymentHistoryPayload>();
        }

        public int Id { get; set; }
        public DateTime RunDate { get; set; }
        public bool? IsRunSuccessful { get; set; }
        public int CompanyId { get; set; }
        public int ClientId { get; set; }

        public virtual ICollection<PaymentHistoryPayload> PaymentHistoryPayload { get; set; }
    }
}
