using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class Company
    {
        public Company()
        {
            CompanyDiscount = new HashSet<CompanyDiscount>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string PrimaryEmail { get; set; }
        public string Phone { get; set; }
        public string Zip { get; set; }
        public int CompanyTypeId { get; set; }
        public string AddressLine2 { get; set; }
        public decimal? Vatpercentage { get; set; }
        public decimal? OtherCharges { get; set; }

        public virtual CompanyType CompanyType { get; set; }
        public virtual ICollection<CompanyDiscount> CompanyDiscount { get; set; }
    }
}
