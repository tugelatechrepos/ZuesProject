using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetTypeTableListRequest
    {
        public bool IncludeServiceTypeList { get; set; }
        public bool IncludeUserList { get; set; }
    }
}
