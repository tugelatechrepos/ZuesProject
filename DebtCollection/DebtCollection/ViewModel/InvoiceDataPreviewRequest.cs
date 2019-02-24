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
        public AccountBalanceManager.Contracts.InvoiceDetail InvoiceDetail { get; set; }

        public IInvoiceHelper InvoiceHelper { get; set; }
    }
}
