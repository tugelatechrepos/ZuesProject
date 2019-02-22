using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWizard
{
    public partial class AccountOpeningBalance
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public double OpeningBalance { get; set; }
        public int PeriodId { get; set; }
    }

    public class PersistAccountOpeningBalanceListRequest
    {
        public ICollection<AccountOpeningBalance> AccountOpeningBalanceList { get; set; }
    }

    public class PersistAccountOpeningBalanceListResponse
    {

    }


    public class AccountOpeningBalanceDBUtility
    {
        public static PersistAccountOpeningBalanceListResponse PersistAccountOpeningBalanceList(PersistAccountOpeningBalanceListRequest Request)
        {
            var daoHelper = new DaoHelper();

            var daoResponse = daoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"accountOpeningBalance/persist",
                RequestBody = Request
            });

            var response = JsonConvert.DeserializeObject<PersistAccountOpeningBalanceListResponse>(daoResponse.data);

            return response;
        }
    }
}
