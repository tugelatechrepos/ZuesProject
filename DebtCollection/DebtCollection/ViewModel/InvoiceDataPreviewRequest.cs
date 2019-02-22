using DebtCollection.ServiceHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ViewModel
{
    public class InvoiceDataPreviewRequest
    {
        public int InvoiceId { get; set; }
        public Period Period { get; set; }
        public Period PreviousPeriod { get; set; }

        public InvoiceDetail InvoiceDetail { get; set; }

        public IInvoiceHelper InvoiceHelper { get; set; }
    }
}
