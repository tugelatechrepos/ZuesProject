using AccountBalanceManager.Client;
using ProjectCoreLibrary;

namespace SAPGUI
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
