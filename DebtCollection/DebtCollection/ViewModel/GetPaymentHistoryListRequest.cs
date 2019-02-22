using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ViewModel
{
    public class GetPaymentHistoryListRequest
    {
        public ICollection<int> AccountIdList { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? InvoiceId { get; set; }
    }
}
