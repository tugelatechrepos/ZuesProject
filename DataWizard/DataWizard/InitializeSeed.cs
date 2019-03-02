using DebtCollectionAccess;
using DebtCollectionAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWizard
{
    public class InitializeSeed
    {
        private PaymentHistoryDBUtility _PaymentHistoryDBUtility;
        private AccountDataUtility _AccountDatatUtility;
        private ICollection<PaymentHistory> _PaymentHistoryList;
        private ICollection<Period> _PeriodList;
        private DateTime _FirstDate;
        private DateTime _LastDate;
        private bool _AnyNewPeriod;
        private bool _IsPersistPaymentHistoryCalled;

        public void Initialize()
        {
            _PaymentHistoryDBUtility = new PaymentHistoryDBUtility();
            _AccountDatatUtility = new AccountDataUtility();

            execute();
        }

        private void execute()
        {
            assignDataFromUtility();
            assignPeriodList();
            assignDateParameters();
            createPeriodList();
            insertPeriodListIfAny();
            assignCreateAccountOpeningBalanceList();
            registerAccountBalances();
        }

        private void assignDataFromUtility()
        {
            if (_PaymentHistoryList != null && _PaymentHistoryList.Any()) return;

            _PaymentHistoryList = _AccountDatatUtility.GetpaymentHistoryListData();
            persistPaymentHistoryList();
        }

        private void assignPeriodList()
        {
            var response = PeriodDBUtility.GetPeriodList(new GetPeriodListRequest());

            _PeriodList = response.PeriodList;
        }

        private void assignDateParameters()
        {
            _FirstDate = _PaymentHistoryList.OrderBy(x => x.PaymentDate).FirstOrDefault().PaymentDate;
            _LastDate = _PaymentHistoryList.OrderByDescending(x => x.PaymentDate).FirstOrDefault().PaymentDate;
        }

        private void createPeriodList()
        {
            if (_PeriodList != null && _PeriodList.Any()) return;

            var periodList = new List<Period>();
            var firstmonth = _FirstDate.Month;
            var lastMonth = _LastDate.Month;

            var counterDate = _FirstDate;
            while (counterDate <= _LastDate)
            {
                var lastDayOfTheMonth = DateTime.DaysInMonth(counterDate.Year, counterDate.Month);

                var period = new Period
                {
                    FromDate = new DateTime(counterDate.Year, counterDate.Month, 1),
                    ToDate = new DateTime(counterDate.Year, counterDate.Month, lastDayOfTheMonth),
                    Name = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(counterDate.Month)} {counterDate.Year}"
                };

                periodList.Add(period);
                counterDate = counterDate.AddMonths(1);
            }

            persistPeriodList(periodList);
        }

        private void insertPeriodListIfAny()
        {
            if (_PeriodList == null || !_PeriodList.Any()) return;

            var fromDate = new DateTime(_FirstDate.Year, _FirstDate.Month, 1);
            var lastDay = DateTime.DaysInMonth(_LastDate.Year, _LastDate.Month);
            var toDate = new DateTime(_LastDate.Year, _LastDate.Month, lastDay);


            var counterDate = fromDate;
            _AnyNewPeriod = false;
            while (counterDate <= toDate)
            {
                var lastDayOfTheMonth = DateTime.DaysInMonth(counterDate.Year, counterDate.Month);
                var toDateOfTheMonth = new DateTime(counterDate.Year, counterDate.Month, lastDayOfTheMonth);
                var paymentRecordList = _PaymentHistoryList.Where(x => x.PaymentDate >= counterDate && x.PaymentDate <= toDateOfTheMonth);

                var period = _PeriodList.FirstOrDefault(x => x.FromDate >= counterDate && x.ToDate <= toDateOfTheMonth);

                if (period != null) { counterDate = counterDate.AddMonths(1); continue; }
                _AnyNewPeriod = true;
                var newPeriod = new Period
                {
                    FromDate = counterDate,
                    ToDate = toDateOfTheMonth,
                    Name = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(counterDate.Month)} {counterDate.Month}"
                };

                _PeriodList.Add(newPeriod);
                counterDate = counterDate.AddMonths(1);
            }

            if (!_AnyNewPeriod) return;
            persistPeriodList(_PeriodList);
        }

        private void persistPaymentHistoryList()
        {
            _IsPersistPaymentHistoryCalled = true;
            PaymentHistoryDBUtility.PersistData(_PaymentHistoryList);
        }

        private void persistPeriodList(ICollection<Period> PeriodList)
        {
            PeriodDBUtility.PersistPeriodList(new PersistPeriodListRequest { PeriodList = PeriodList });
        }

        private void assignCreateAccountOpeningBalanceList()
        {
            if (!_IsPersistPaymentHistoryCalled) return;

            var response = PeriodDBUtility.GetPeriodList(new GetPeriodListRequest());
            var periodList = response.PeriodList;

            var accountIdList = _PaymentHistoryList.Select(x => x.AccountId).Distinct().ToList();

            var currentMonth = DateTime.Now.Date.Month;
            var currentYear = DateTime.Now.Date.Year;

            var currentPeriod = periodList.FirstOrDefault(x => x.FromDate.Month == currentMonth && x.FromDate.Year == currentYear);

            if (currentPeriod == null) return;

            var accountOpeningBalanceList = accountIdList.Select(x => new AccountOpeningBalance
            {
                AccountId = x,
                OpeningBalance = 5000,
                PeriodId = currentPeriod.Id
            }).ToList();

            AccountOpeningBalanceDBUtility.PersistAccountOpeningBalanceList(new PersistAccountOpeningBalanceListRequest
            { AccountOpeningBalanceList = accountOpeningBalanceList });
        }

        private void registerAccountBalances()
        {
            if (_IsPersistPaymentHistoryCalled || _AnyNewPeriod)
            {
                AcccountBalanceUtility.RegisterAccountBalances();
            }
        }

    }
}
