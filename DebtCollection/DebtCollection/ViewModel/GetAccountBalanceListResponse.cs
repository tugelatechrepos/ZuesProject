using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ViewModel
{
    public class GetAccountBalanceListResponse
    {
        public ICollection<AccountBalance> AccountBalanceList { get; set; }
    }
}
