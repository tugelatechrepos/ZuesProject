using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPGUI
{
    public class AcccountBalanceUtility
    {
        public static void RegisterAccountBalances()
        {
            var daoHelper = new DaoHelper();
            var response = daoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"accountBalance/maintain",
                UseServiceUri = true,
            });
        }
    }
}
