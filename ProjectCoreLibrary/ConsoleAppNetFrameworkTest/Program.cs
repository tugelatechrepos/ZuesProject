using DebtCollectionAccess.Operations;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNetFrameworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var operation = IOCManager.Resolve<IGetPeriodListOperation>();
            var periodList = operation.GetPeriodList(new DebtCollectionAccess.Contracts.GetPeriodListRequest());
            Console.ReadLine();
        }
    }
}
