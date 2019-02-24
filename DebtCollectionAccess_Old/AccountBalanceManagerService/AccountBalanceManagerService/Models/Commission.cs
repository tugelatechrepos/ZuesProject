using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Models
{
    public class Commission
    {
        public int Id { get; set; }
        public double LowerRange { get; set; }
        public double HigherRange { get; set; }
        public double CommissionPercentage { get; set; }
    }
}