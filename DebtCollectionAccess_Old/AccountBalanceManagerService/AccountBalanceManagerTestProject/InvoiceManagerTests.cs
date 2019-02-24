using System;
using System.Collections.Generic;
using AccountBalanceManagerService;
using AccountBalanceManagerService.Processor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AccountBalanceManagerTestProject
{
    [TestClass]
    public class InvoiceManagerTests : TestBase
    {
        [TestMethod]
        public void GenerateInvoiceTest()
        {
            var processor = IocManager.Resolve<IGenerateInvoiceProcessor>();
            var response = processor.GenerateInvoice(new GenerateInvoiceProcessorRequest());
        }

        [TestMethod]
        public void GetInvoiceListTest()
        {
            var processor = IocManager.Resolve<IInvoiceProcessor>();
            var response = processor.GetInvoiceList(new GetInvoiceListRequest { PeriodIdList = new List<int> { 18 } });
        }
    }
}
