using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ViewModel
{
    public class GetInvoiceListRequest
    {
        public ICollection<int> InvoiceIdList { get; set; }
        public ICollection<int> PeriodIdList { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
