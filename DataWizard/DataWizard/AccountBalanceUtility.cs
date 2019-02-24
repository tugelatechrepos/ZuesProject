using AccountBalanceManager.Client;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWizard
{
    public class AcccountBalanceUtility
    {
        public static void RegisterAccountBalances()
        {
            var accountBalanceManagerProxy = IOCManager.Resolve<IAccountBalanceManagerProxy>();
            var response = accountBalanceManagerProxy.MaintainAccountBalance();
            //var daoHelper = new DaoHelper();
            //var response = daoHelper.Execute(new DaoHelperRequest
            //{
            //    Endpoint = @"accountBalance/maintain",
            //    UseServiceUri = true,
            //});
        }
    }
}
