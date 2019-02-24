using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public DateTime GeneratedOn { get; set; }
        public int? PeriodId { get; set; }
    }
}