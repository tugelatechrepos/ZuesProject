using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class PaymentHistoryPayload
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Payload { get; set; }
        public int PaymentHistoryPayloadPeriodId { get; set; }

        public virtual PaymentHistoryPayloadPeriod PaymentHistoryPayloadPeriod { get; set; }
    }
}
