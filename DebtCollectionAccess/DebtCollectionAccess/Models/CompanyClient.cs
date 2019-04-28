using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class CompanyClient
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ClientId { get; set; }

        public virtual Company Client { get; set; }
        public virtual Company Company { get; set; }
    }
}
