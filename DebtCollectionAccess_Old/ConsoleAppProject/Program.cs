using DebtCollectionAccess;
using DebtCollectionAccess.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var operation = IocManager.Resolve<IGetPeriodListOperation>();
                var response = operation.GetPeriodList(new DebtCollectionAccess.Contracts.GetPeriodListRequest
                {

                });

                Console.WriteLine("Working fine");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
