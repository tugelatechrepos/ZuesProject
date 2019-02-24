using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Operations;
using ProjectCoreLibrary;
using System;

namespace ConsoleAppNetCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = IOCManager.Instance;
            var operation = IOCManager.Resolve<IGetPeriodListOperation>();
            var periodList = operation.GetPeriodList(new GetPeriodListRequest());
            Console.ReadLine();
        }
    }
}
