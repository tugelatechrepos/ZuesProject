using DebtCollectionAccess;
using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AccessTestProject
{
    public class PersistPeriodListOperationTests
    {
        [Fact]
        public void PersistPeriodListOperation_SanityCheckTest()
        {
            var operation = IocManager.Resolve<IPersistPeriodListOperation>();
            var request = new PersistPeriodListRequest
            {
                PeriodList = getPeriodList(),
            };

            var response = operation.PersistPeriodList(request);
        }

        private ICollection<Period> getPeriodList()
        {
            var periodList = new List<Period>
            {
                new Period{FromDate = new DateTime(2019,01,01),ToDate = new DateTime(2019,01,31), Name = "Jan Invoice Cycle", IsInvoiced = false},
                new Period{FromDate = new DateTime(2019,02,01),ToDate = new DateTime(2019,02,28),Name = "Feb Invoice Cycle",IsInvoiced = false},
                new Period{FromDate = new DateTime(2019,03,01),ToDate = new DateTime(2019,01,31),Name = "March Invoice Cycle",IsInvoiced = false},
                new Period{FromDate = new DateTime(2019,04,01),ToDate = new DateTime(2019,04,30),Name = "April Invoice Cycle",IsInvoiced = false},
                new Period{FromDate = new DateTime(2019,05,01),ToDate = new DateTime(2019,05,31),Name = "May Invoice Cycle",IsInvoiced = false},
            };

            return periodList;
        }
    }
}
