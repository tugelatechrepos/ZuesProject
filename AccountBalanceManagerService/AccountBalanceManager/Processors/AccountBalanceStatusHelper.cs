using AccountBalanceManager.Enum;
using DebtCollectionAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalanceManager.Processors
{
    public class AccountBalanceStatusHelper
    {
        public static AccountBalanceStatusEnum GetAccountBalanceStatus(AccountBalance AccountBalance)
        {
            if (!AccountBalance.PromisedAmount.HasValue) return AccountBalanceStatusEnum.None;

            if (AccountBalance.IsPartialPayment.HasValue && AccountBalance.IsPartialPayment.Value) return AccountBalanceStatusEnum.IsPartialPayment;

            if (AccountBalance.IsPaymentMissed.HasValue && AccountBalance.IsPaymentMissed.Value) return AccountBalanceStatusEnum.IsPaymentMissed;

            if (AccountBalance.RemainingBalance.Value == 0) return AccountBalanceStatusEnum.IsFullyPaid;

            return AccountBalanceStatusEnum.None;
        }
    }
}
