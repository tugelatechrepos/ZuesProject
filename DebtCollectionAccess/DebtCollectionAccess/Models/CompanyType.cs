using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class CompanyType
    {
        public CompanyType()
        {
            Company = new HashSet<Company>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Company> Company { get; set; }
    }
}
