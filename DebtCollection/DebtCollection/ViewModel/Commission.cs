using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ViewModel
{
    public partial class Commission
    {
        public int Id { get; set; }
        public decimal LowerRange { get; set; }
        public decimal HigherRange { get; set; }
        public decimal CommissionPercentage { get; set; }
    }
}
