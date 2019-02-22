using AccountBalanceManagerService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace AccountBalanceManagerService.Processor
{
    public interface ICommissionProcessor
    {
        GetCommissionProcessorResponse GetCommission(GetCommissionProcessorRequest Request);
    }

    public class GetCommissionProcessorRequest
    {
        public decimal Yield { get; set; }
    }

    public class GetCommissionProcessorResponse
    {
        public Commission Commission { get; set; }
    }

   
    public class CommissionProcessor : ICommissionProcessor
    {
        #region Declarations

       
        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GetCommissionProcessorResponse GetCommission(GetCommissionProcessorRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = "commission",
                RequestBody = Request
            });

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetCommissionProcessorResponse>(daoResponse.data);

            return response;
        }
    }
}