using DebtCollectionAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWizard
{
    public class AccountDayServiceAmount
    {
        public int AccountId { get; set; }

        public ICollection<DayServiceAmount> DayServiceAmountList { get; set; }
    }

    public class DayServiceAmount
    {
        public int Day { get; set; }
        public long ServiceId { get; set; }
        public decimal Amount { get; set; }
    }

    public class AccountDataUtility
    {
        private List<AccountDayServiceAmount> _AccountDayServiceAmountList;
        private ICollection<int> _AccountIdList = new List<int> { 135216, 131613, 142502, 142238, 140022 };
        private ICollection<PaymentHistory> _PaymentHistoryList;
        private const int COMPANY_ID = 3;

        public ICollection<PaymentHistory> GetpaymentHistoryListData()
        {
            _PaymentHistoryList = new List<PaymentHistory>();

            assignAccountDayServiceAmountList();
            assignPaymentHistoryList();

            return _PaymentHistoryList;
        }

        public void assignAccountDayServiceAmountList()
        {
            _AccountDayServiceAmountList = new List<AccountDayServiceAmount>();

            _AccountDayServiceAmountList.Add(new AccountDayServiceAmount
            {
                AccountId = 135216,
                DayServiceAmountList = new List<DayServiceAmount>
                {
                    new DayServiceAmount{Day = 2, ServiceId = 30000752663,Amount = 5},
                    new DayServiceAmount{Day = 4, ServiceId = 30000752622,Amount = 5},
                    new DayServiceAmount{Day = 6, ServiceId = 30000752583,Amount = 5},
                    new DayServiceAmount{Day = 7, ServiceId = 30000752663,Amount = 5},
                    new DayServiceAmount{Day = 8, ServiceId = 30000752622,Amount = 5},
                }
            });

            _AccountDayServiceAmountList.Add(new AccountDayServiceAmount
            {
                AccountId = 131613,
                DayServiceAmountList = new List<DayServiceAmount>
                {

                    new DayServiceAmount{Day = 1, ServiceId = 30000752663,Amount = 8},
                    new DayServiceAmount{Day = 2, ServiceId = 30000752622,Amount = 12},
                    new DayServiceAmount{Day = 4, ServiceId = 30000752583,Amount = 5},
                    new DayServiceAmount{Day = 5, ServiceId = 30000752663,Amount = 5},
                    new DayServiceAmount{Day = 6, ServiceId = 30000752622,Amount = 5},

                }
            });

            _AccountDayServiceAmountList.Add(new AccountDayServiceAmount
            {
                AccountId = 142502,
                DayServiceAmountList = new List<DayServiceAmount>
                {

                    new DayServiceAmount{Day = 1, ServiceId = 30000752663,Amount = 8 },
                    new DayServiceAmount{Day = 3, ServiceId = 30000752622,Amount = 20 },
                    new DayServiceAmount{Day = 5, ServiceId = 30000752583,Amount = 10 },
                    new DayServiceAmount{Day = 7, ServiceId = 30000752663,Amount = 5},
                    new DayServiceAmount{Day = 9, ServiceId = 30000752622,Amount = 5 },

                }
            });

            _AccountDayServiceAmountList.Add(new AccountDayServiceAmount
            {
                AccountId = 142238,
                DayServiceAmountList = new List<DayServiceAmount>
                {
                     new DayServiceAmount{Day = 2, ServiceId = 30000752663,Amount = 0},
                    new DayServiceAmount{Day = 3, ServiceId = 30000752622,Amount = 0},
                    new DayServiceAmount{Day = 5, ServiceId = 30000752583,Amount = 0},
                    new DayServiceAmount{Day = 6, ServiceId = 30000752663,Amount = 0},
                    new DayServiceAmount{Day = 7, ServiceId = 30000752622,Amount = 0},

                    //new DayServiceAmount{Day = 2, ServiceId = 30000752663,Amount = 10},
                    //new DayServiceAmount{Day = 3, ServiceId = 30000752622,Amount = 5},
                    //new DayServiceAmount{Day = 5, ServiceId = 30000752583,Amount = 10},
                    //new DayServiceAmount{Day = 6, ServiceId = 30000752663,Amount = 5},
                    //new DayServiceAmount{Day = 7, ServiceId = 30000752622,Amount = 5},

                }
            });

            _AccountDayServiceAmountList.Add(new AccountDayServiceAmount
            {
                AccountId = 140022,
                DayServiceAmountList = new List<DayServiceAmount>
                {

                    new DayServiceAmount{Day = 1, ServiceId = 30000752663,Amount = 5},
                    new DayServiceAmount{Day = 2, ServiceId = 30000752622,Amount = 5},
                    new DayServiceAmount{Day = 4, ServiceId = 30000752583,Amount = 5},
                    new DayServiceAmount{Day = 5, ServiceId = 30000752663,Amount = 5},
                    new DayServiceAmount{Day = 6, ServiceId = 30000752622,Amount = 5},
                }
            });
        }

        private void assignPaymentHistoryList()
        {
            var Date = DateTime.Now.AddMonths(1);

            for (int i = 1; i <= 4; i++)
            {
                Date = Date.AddMonths(-1);

                foreach (var accountId in _AccountIdList)
                {
                    create(accountId, Date);
                }
            }
        }

        private void create(int accountId, DateTime Date)
        {

            var dayserviceAmountList = _AccountDayServiceAmountList.FirstOrDefault(x => x.AccountId == accountId).DayServiceAmountList;

            foreach (var dayServiceAmount in dayserviceAmountList)
            {
                _PaymentHistoryList.Add(new PaymentHistory
                {
                    AccountId = accountId,
                    PaymentDate = new DateTime(Date.Year, Date.Month, dayServiceAmount.Day),
                    ServiceId = dayServiceAmount.ServiceId,
                    Amount = dayServiceAmount.Amount,
                    PaymentMode = "Manual Payment",
                    CompanyId = COMPANY_ID
                });
            }
        }

    }
}
