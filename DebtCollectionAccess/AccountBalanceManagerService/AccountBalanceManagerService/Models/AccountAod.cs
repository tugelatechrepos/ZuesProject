﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Models
{
    public class AccountAod
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int PeriodId { get; set; }
        public decimal? Amount { get; set; }
    }
}