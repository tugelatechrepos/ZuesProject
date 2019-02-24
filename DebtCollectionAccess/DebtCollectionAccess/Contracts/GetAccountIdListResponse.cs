using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetAccountIdListResponse
    {
        public ICollection<int> AccountIdList { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }
}
