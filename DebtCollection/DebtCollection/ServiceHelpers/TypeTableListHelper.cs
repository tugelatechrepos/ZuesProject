using DebtCollection.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ServiceHelpers
{
    public interface ITypeTableListHelper
    {
        GetTypeTableListResponse GetTypeTableList(GetTypeTableListRequest Request);
    }

    public class TypeTableListHelper : ITypeTableListHelper
    {
        #region Declarations

        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetTypeTableListResponse GetTypeTableList(GetTypeTableListRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"TableType/list",
                RequestBody = Request
            });

            var response = JsonConvert.DeserializeObject<GetTypeTableListResponse>(daoResponse.data);

            return response;
        }
    }
}
