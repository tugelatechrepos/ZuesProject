
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class PersistPeriodListRequest
    {
        public ICollection<Period> PeriodList { get; set; }
    }
}
