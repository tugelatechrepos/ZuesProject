using System;
using System.Net.Http;
using AccountBalanceManagerService;
using AccountBalanceManagerService.Processor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace AccountBalanceManagerTestProject
{
    [TestClass]
    public class AccountBalanceManagerTests : TestBase
    {
        [TestMethod]
        public void AccountBalanceManager_CalculationTest()
        {
            var processor = IocManager.Resolve<IAccountBalanceCalculationProcessor>();
            var response = processor.ProcessAccountBalanceList(new AccountBalanceCalculationProcessorRequest());
        }
    }
}
