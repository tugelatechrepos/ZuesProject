using DebtCollectionAccess;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalanceManager.Contracts
{
    public class GetInvoiceListResponse
    {
        public ICollection<Invoice> InvoiceList { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetailList { get; set; }
        public ValidationResults ValidationResults { get; set; }
    }
}
