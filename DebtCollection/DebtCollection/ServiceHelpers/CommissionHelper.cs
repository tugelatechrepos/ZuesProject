using DebtCollectionAccess.Client;
using DebtCollectionAccess.Contracts;
using Newtonsoft.Json;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ServiceHelpers
{
    public interface ICommissionHelper
    {
        GetCommissionResponse GetCommission(GetCommissionRequest Request);
    }

    public class CommissionHelper : ICommissionHelper
    {
        #region Declarations

        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetCommissionResponse GetCommission(GetCommissionRequest Request)
        {
            var accessProxy = IOCManager.Resolve<IDebtCollectionAccessProxy>();
            var response = accessProxy.GetCommission(Request);

            //var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            //{
            //    Endpoint = @"commission",
            //    RequestBody = Request
            //});

            //var response = JsonConvert.DeserializeObject<GetCommissionResponse>(daoResponse.data);

            return response;
        }
    }
}
