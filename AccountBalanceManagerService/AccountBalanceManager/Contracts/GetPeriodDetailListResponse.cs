using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalanceManager.Contracts
{
    public class GetPeriodDetailListResponse
    {
        public ICollection<PeriodDetail> PeriodDetailList { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }
}
