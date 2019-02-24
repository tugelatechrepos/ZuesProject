using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetPaymentHistoryListRequest
    {
        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public ICollection<int> AccountIdList { get; set; }

        public int? InvoiceId { get; set; }

        public int Skip { get; set; }

        public int Take { get; set; }
    }
}
