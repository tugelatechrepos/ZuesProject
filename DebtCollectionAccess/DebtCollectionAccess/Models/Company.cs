using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class Company
    {
        public Company()
        {
            AccountBalance = new HashSet<AccountBalance>();
            AgencyCompanyAgency = new HashSet<AgencyCompany>();
            AgencyCompanyClient = new HashSet<AgencyCompany>();
            CompanyDiscount = new HashSet<CompanyDiscount>();
            Invoice = new HashSet<Invoice>();
            Period = new HashSet<Period>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string PrimaryEmail { get; set; }
        public string Phone { get; set; }
        public string Zip { get; set; }
        public int CompanyTypeId { get; set; }
        public string AddressLine2 { get; set; }
        public double? Vatpercentage { get; set; }
        public double? OtherCharges { get; set; }

        public virtual CompanyType CompanyType { get; set; }
        public virtual ICollection<AccountBalance> AccountBalance { get; set; }
        public virtual ICollection<AgencyCompany> AgencyCompanyAgency { get; set; }
        public virtual ICollection<AgencyCompany> AgencyCompanyClient { get; set; }
        public virtual ICollection<CompanyDiscount> CompanyDiscount { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
        public virtual ICollection<Period> Period { get; set; }
    }
}
