using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class PersistInvoiceResponse
    {
        public int InvoiceId { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }
}
