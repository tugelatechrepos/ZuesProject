using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalanceManager.Enum
{
    public enum AccountBalanceStatusEnum
    {
        None = 0,
        IsPartialPayment = 1,
        IsPaymentMissed = 2,
        IsFullyPaid = 3
    }
}
