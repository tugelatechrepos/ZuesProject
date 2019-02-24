using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class Users
    {
        public Users()
        {
            AccountBalance = new HashSet<AccountBalance>();
            AccountOwner = new HashSet<AccountOwner>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<AccountBalance> AccountBalance { get; set; }
        public virtual ICollection<AccountOwner> AccountOwner { get; set; }
    }
}
