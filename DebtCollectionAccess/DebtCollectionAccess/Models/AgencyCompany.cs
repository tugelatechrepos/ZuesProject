using System;
using System.Collections.Generic;

namespace DebtCollectionAccess
{
    public partial class AgencyCompany
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public int ClientId { get; set; }

        public virtual Company Agency { get; set; }
        public virtual Company Client { get; set; }
    }
}
