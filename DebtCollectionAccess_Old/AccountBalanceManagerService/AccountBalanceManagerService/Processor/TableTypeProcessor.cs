using AccountBalanceManagerService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Processor
{
    public interface ITableTypeProcessor
    {
        GetTableTypeProcessorResponse GetTableTypeList(GetTableTypeProcessorRequest Request);
    }

    public class GetTableTypeProcessorRequest
    {
        public bool IncludeServiceTypeList { get; set; }
        public bool IncludeUserList { get; set; }
    }

    public class GetTableTypeProcessorResponse
    {
        public ICollection<ServiceType> ServiceTypeList { get; set; }
        public ICollection<Users> UserList { get; set; }
    }

 
    public class TableTypeProcessor : ITableTypeProcessor
    {
        #region Declarations

       
        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetTableTypeProcessorResponse GetTableTypeList(GetTableTypeProcessorRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = "TypeTable/list",
                RequestBody = Request
            });

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetTableTypeProcessorResponse>(daoResponse.data);

            return response;
        }
    }
}