using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalanceManager.Contracts
{
    public class GenerateInvoiceRequest
    {
        public int PeriodId { get; set; }

        public int CompanyId { get; set; }
    }
}
