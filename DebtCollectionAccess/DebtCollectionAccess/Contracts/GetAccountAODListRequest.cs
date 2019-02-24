using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetAccountAODListRequest
    {
        public ICollection<int> AccountIdList { get; set; }
        public ICollection<int> PeriodIdList { get; set; }
    }
}
