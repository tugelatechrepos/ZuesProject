using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ViewModel
{
    public class Period
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime? RunDate { get; set; }
        public string Name { get; set; }
        public bool? IsInvoiced { get; set; }
    }
}
