using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class Commission
    {
        public int Id { get; set; }
        public decimal LowerRange { get; set; }
        public decimal HigherRange { get; set; }
        public decimal CommissionPercentage { get; set; }
    }
}
