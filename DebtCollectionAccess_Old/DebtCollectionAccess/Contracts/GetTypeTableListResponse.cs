using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetTypeTableListResponse
    {
        public ICollection<ServiceType> ServiceTypeList { get; set; }

        public ICollection<Users> UserList { get; set; }
    }
}
