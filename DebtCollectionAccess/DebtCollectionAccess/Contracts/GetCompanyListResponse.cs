using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Contracts
{
    public class GetCompanyListResponse
    {
        public ICollection<Company> CompanyList { get; set; }

        public ValidationResults ValidationResults { get; set; }
    }
}
