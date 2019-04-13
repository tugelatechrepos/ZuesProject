using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetCompanyListRequest
    {
        public ICollection<int> CompanyIdList { get; set; }
    }
}
