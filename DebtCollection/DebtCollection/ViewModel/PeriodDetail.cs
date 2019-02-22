using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ViewModel
{
    public class GetPeriodDetailListProcessorRequest
    {
        
    }

    public class GetPeriodDetailListProcessorResponse
    {
        public ICollection<PeriodDetail> PeriodDetailList { get; set; }
    }

    public class PeriodDetail
    {
        public int PeriodId { get; set; }

        public string Name { get; set; }

        public decimal TotalOpeningBalance { get; set; }

        public decimal TargetYield { get; set; }

        public decimal RemainingBalance { get; set; }

        public bool Readiness { get; set; }

        public decimal TotalPaid { get; set; }
    }
}
