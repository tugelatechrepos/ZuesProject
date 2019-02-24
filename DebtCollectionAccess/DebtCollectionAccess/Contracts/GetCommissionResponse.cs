using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetCommissionResponse
    {
        public Commission Commission { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }
}
