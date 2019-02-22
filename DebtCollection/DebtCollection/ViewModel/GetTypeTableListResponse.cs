using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ViewModel
{
    public class GetTypeTableListResponse
    {
        public ICollection<ServiceType> ServiceTypeList { get; set; }
    }
}
