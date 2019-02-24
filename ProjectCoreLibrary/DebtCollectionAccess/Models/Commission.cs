using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class Commission
    {
        public int Id { get; set; }
        public double LowerRange { get; set; }
        public double HigherRange { get; set; }
        public double CommissionPercentage { get; set; }
    }
}
