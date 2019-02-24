using DebtCollectionAccess.Client;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWizard
{
    public class DataCleanUpUtility
    {
        public static void CleanUp()
        {
            var accessProxy = IOCManager.Resolve<IDebtCollectionAccessProxy>();
            var response = accessProxy.CleanUpData();

            //var daoHelper = new DaoHelper();
            //var response = daoHelper.Execute(new DaoHelperRequest
            //{
            //    Endpoint = @"dataCleanUp/delete"
            //});

        }
    }
}
