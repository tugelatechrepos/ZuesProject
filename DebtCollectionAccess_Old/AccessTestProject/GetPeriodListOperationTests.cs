using DebtCollectionAccess;
using DebtCollectionAccess.Operations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AccessTestProject
{
    public class GetPeriodListOperationTests
    {
        [Fact]
        public void GetPeriodListOperation_SanityCheckTest()
        {
            var operation = IocManager.Resolve<IGetPeriodListOperation>();
            var response = operation.GetPeriodList(new DebtCollectionAccess.Contracts.GetPeriodListRequest());

            Assert.True(response.PeriodList != null);
            Assert.True(response.PeriodList.Count > 0);
        }
    }
}
