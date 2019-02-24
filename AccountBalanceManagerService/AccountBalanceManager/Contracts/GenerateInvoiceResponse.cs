using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalanceManager.Contracts
{
    public class GenerateInvoiceResponse
    {
        public int? InvoiceId { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }
}
