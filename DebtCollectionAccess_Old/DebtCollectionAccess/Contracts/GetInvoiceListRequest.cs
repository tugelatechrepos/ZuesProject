using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetInvoiceListRequest
    {
        public ICollection<int> InvoiceIdList { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public ICollection<int> PeriodIdList { get; set; }
    }
}
