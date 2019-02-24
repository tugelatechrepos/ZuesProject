using DebtCollectionAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPGUI
{
    public class AddDataUtility
    {
        public ICollection<AccountBalanceManager.Contracts.PaymentHistory> Add(ICollection<AccountBalanceManager.Contracts.PaymentHistory> PaymentHistoryList)
        {
            var currentDate = DateTime.Now.Date;
            var lastDayOfTheMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            var fromDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            var toDate = new DateTime(currentDate.Year, currentDate.Month, lastDayOfTheMonth);

            var paymentHistoryList = new List<AccountBalanceManager.Contracts.PaymentHistory>();

            var filteredPaymentHistoryList = PaymentHistoryList.Where(x => x.PaymentDate >= fromDate && x.PaymentDate <= toDate).ToList();

            var accountIdGroupList = filteredPaymentHistoryList.GroupBy(x => x.AccountId).Select(grp => new { acountId = grp.Key, paymentHistoryList = grp.ToList() });

            foreach(var accountGroup in accountIdGroupList)
            {
                var list = accountGroup.paymentHistoryList;
                var highestDate = list.OrderByDescending(x => x.PaymentDate).FirstOrDefault().PaymentDate;
                var dayToAdd = highestDate.Day;
                var lastDay = DateTime.DaysInMonth(highestDate.Year, highestDate.Month);
                int i = 1;

                foreach (var paymentHistory in list)
                {
                    var incrementalDate = dayToAdd + i;

                    if (incrementalDate > lastDay) break;

                    var paymentDate = new DateTime(highestDate.Year, highestDate.Month, incrementalDate);

                    var record = new AccountBalanceManager.Contracts.PaymentHistory
                    {
                        AccountId = paymentHistory.AccountId,
                        PaymentDate = paymentDate,
                        ServiceName = paymentHistory.ServiceName,
                        PaymentMode = paymentHistory.PaymentMode,
                        ServiceId = paymentHistory.ServiceId,
                        Amount = paymentHistory.Amount + 5
                    };
                    i++;

                    paymentHistoryList.Add(record);
                }
            }
            var resultList = paymentHistoryList.OrderBy(x => x.AccountId).ToList();
            return resultList;
        }
    }
}
