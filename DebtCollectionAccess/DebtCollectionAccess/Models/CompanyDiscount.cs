using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class CompanyDiscount
    {
        public int Id { get; set; }
        public decimal? Discount { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
