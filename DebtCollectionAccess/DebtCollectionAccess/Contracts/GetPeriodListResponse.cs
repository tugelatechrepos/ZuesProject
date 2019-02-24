
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetPeriodListResponse
    {
        public ICollection<Period> PeriodList { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }
}
