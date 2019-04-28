using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalanceManager.Contracts
{
    public class GetPeriodListRequest
    {
        public ICollection<int> PeriodIdList { get; set; }
        public int CompanyId { get; set; }
    }
}