using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Models
{
    public partial class AccountOwner
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int OwnerId { get; set; }        
    }
}