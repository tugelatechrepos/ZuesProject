using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class Company
    {
        public Company()
        {
            CompanyAddress = new HashSet<CompanyAddress>();
            CompanyClientClient = new HashSet<CompanyClient>();
            CompanyClientCompany = new HashSet<CompanyClient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ClientTypeId { get; set; }

        public virtual ICollection<CompanyAddress> CompanyAddress { get; set; }
        public virtual ICollection<CompanyClient> CompanyClientClient { get; set; }
        public virtual ICollection<CompanyClient> CompanyClientCompany { get; set; }
    }
}
