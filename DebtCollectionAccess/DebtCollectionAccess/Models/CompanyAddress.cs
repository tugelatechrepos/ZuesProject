using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class CompanyAddress
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }
        public char? PhoneNumber { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
