using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetInvoiceListResponse
    {
        public ICollection<Invoice> InvoiceList { get; set; }
    }
}
