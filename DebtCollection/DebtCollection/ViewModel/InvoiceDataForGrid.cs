using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ViewModel
{
    public class InvoiceDataForGrid
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public decimal TotalOpeningBalance { get; set; }
        public decimal TotalPaid { get; set; }
        public string YieldPercentage { get; set; }
        public decimal CommisionOnYield { get; set; }
        public decimal InvoiceTotal { get; set; }
    }
}
