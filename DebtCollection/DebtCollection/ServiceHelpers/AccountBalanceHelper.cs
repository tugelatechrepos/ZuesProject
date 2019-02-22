using DebtCollection.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ServiceHelpers
{
    public interface IAccountBalanceHelper
    {
        GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request);
    }

    public class AccountBalanceHelper : IAccountBalanceHelper
    {
        #region Declarations

        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"accountBalance/list",
                RequestBody = Request,
                UseServiceUri = true,
            });

            var response = JsonConvert.DeserializeObject<GetAccountBalanceListResponse>(daoResponse.data);

            return response;
        }
    }
}
