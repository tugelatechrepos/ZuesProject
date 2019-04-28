using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentHistoryPayloadManager.Contracts
{
    public class PaymentHistoryPayload
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Payload { get; set; }
        public int PaymentHistoryPayloadPeriodId { get; set; }    
    }
}
