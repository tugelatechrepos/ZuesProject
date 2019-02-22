using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ViewModel
{
    public class GetInvoiceListResponse
    {
        public ICollection<Invoice> InvoiceList { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetailList { get; set; }
    }
}
