using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetPeriodListRequest
    {
        public ICollection<int> PeriodIdList { get; set; }
    }
}
