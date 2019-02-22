using DebtCollection.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.ServiceHelpers
{
    public interface IInvoiceHelper
    {
        GenerateInvoiceResponse GenerateInvoice();

        GetInvoiceListResponse GetInvoiceList(ViewModel.GetInvoiceListRequest Request);

        PersistInvoiceResponse PersistInvoice(PersistInvoiceRequest Request);
    }

    
    public class InvoiceHelper : IInvoiceHelper
    {
        #region Declarations

        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GenerateInvoiceResponse GenerateInvoice()
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest    
            {
                Endpoint = @"invoice/generate",
                UseServiceUri = true,
            });

            var response =  JsonConvert.DeserializeObject<GenerateInvoiceResponse>(daoResponse.data);

            return response;
        }

        public PersistInvoiceResponse PersistInvoice(PersistInvoiceRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"invoice/persist",
                RequestBody = Request
            });

            var response = JsonConvert.DeserializeObject<PersistInvoiceResponse>(daoResponse.data);

            return response;
        }

        public GetInvoiceListResponse GetInvoiceList(ViewModel.GetInvoiceListRequest Request)
        {
            var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            {
                Endpoint = @"invoice/list",
                RequestBody = Request,
                UseServiceUri = true,
            });

            var response = JsonConvert.DeserializeObject<GetInvoiceListResponse>(daoResponse.data);

            return response;
        }
    }
}
