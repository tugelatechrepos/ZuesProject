using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class Period
    {
        public Period()
        {
            AccountBalance = new HashSet<AccountBalance>();
            AccountOpeningBalance = new HashSet<AccountOpeningBalance>();
            Invoice = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime? RunDate { get; set; }
        public string Name { get; set; }
        public bool? IsInvoiced { get; set; }
        public int? CompanyId { get; set; }

        public virtual ICollection<AccountBalance> AccountBalance { get; set; }
        public virtual ICollection<AccountOpeningBalance> AccountOpeningBalance { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
