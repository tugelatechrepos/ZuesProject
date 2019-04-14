using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetAccountBalanceListRequest
    {
        public ICollection<int> AccountIdList { get; set; }
        public ICollection<int> PeriodIdList { get; set; }
        public int CompanyId { get; set; }
        public ICollection<int> StatusIdList { get; set; }
    }
}
