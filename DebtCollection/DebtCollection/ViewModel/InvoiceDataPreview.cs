using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ViewModel
{
    public class InvoiceDataPreview
    {
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Commission { get; set; }
    }
}
