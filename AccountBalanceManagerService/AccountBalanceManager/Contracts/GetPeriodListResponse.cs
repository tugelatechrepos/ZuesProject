using DebtCollectionAccess;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalanceManager.Contracts
{
    public class GetPeriodListResponse
    {
        public ICollection<Period> PeriodList { get; set; }
        public ValidationResults ValidationResults { get; set; }
    }
}