using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class PersistPaymentHistoryListRequest
    {
        public ICollection<PaymentHistory> PaymentHistoryList { get; set; }
    }
}
