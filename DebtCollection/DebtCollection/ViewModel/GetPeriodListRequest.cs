﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ViewModel
{
    public class GetPeriodListRequest
    {
        public ICollection<int> PeriodIdList { get; set; }
    }
}
