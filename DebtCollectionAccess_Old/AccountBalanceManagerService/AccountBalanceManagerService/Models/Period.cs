using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Models
{
    public class Period
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime? RunDate { get; set; }
    }
}
