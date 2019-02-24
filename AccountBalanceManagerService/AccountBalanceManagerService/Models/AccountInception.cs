using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Models
{
    public class AccountInception
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public DateTime StartDate { get; set; }
    }
}