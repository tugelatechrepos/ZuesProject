using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentHistoryPayloadManager.Contracts
{
    public class PaymentHistoryPayloadPeriod
    {
        public int Id { get; set; }
        public DateTime RunDate { get; set; }
        public bool? IsRunSuccessful { get; set; }
        public int CompanyId { get; set; }
        public int ClientId { get; set; }
    }
}
