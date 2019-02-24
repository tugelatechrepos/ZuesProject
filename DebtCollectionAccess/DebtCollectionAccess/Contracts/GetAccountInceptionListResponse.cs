using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetAccountInceptionListResponse
    {
        public ICollection<AccountInception> AccountInceptionList { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }
}
