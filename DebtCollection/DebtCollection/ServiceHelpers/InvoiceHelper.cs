using AccountBalanceManager.Client;
using AccountBalanceManager.Contracts;
using DebtCollectionAccess.Client;
using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;

namespace DebtCollection.ServiceHelpers
{
    public interface IInvoiceHelper
    {
        GenerateInvoiceResponse GenerateInvoice(GenerateInvoiceRequest Request);

        AccountBalanceManager.Contracts.GetInvoiceListResponse GetInvoiceList(GetInvoiceListRequest Request);

        PersistInvoiceResponse PersistInvoice(PersistInvoiceRequest Request);
    }

    
    public class InvoiceHelper : IInvoiceHelper
    {
        #region Declarations

        public IDaoHelper DaoHelper { get; set; }

        #endregion Declarations

        public GenerateInvoiceResponse GenerateInvoice(GenerateInvoiceRequest Request)
        {
            var accountBalanceManagerProxy = IOCManager.Resolve<IAccountBalanceManagerProxy>();
            var response = accountBalanceManagerProxy.GenerateInvoice(Request);

            //var daoResponse = DaoHelper.Execute(new DaoHelperRequest    
            //{
            //    Endpoint = @"invoice/generate",
            //    UseServiceUri = true,
            //});

            //var response =  JsonConvert.DeserializeObject<GenerateInvoiceResponse>(daoResponse.data);

            return response;
        }

        public PersistInvoiceResponse PersistInvoice(PersistInvoiceRequest Request)
        {
            var accessProxy = IOCManager.Resolve<IDebtCollectionAccessProxy>();
            var response = accessProxy.PersistInvoice(Request);
            //var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            //{
            //    Endpoint = @"invoice/persist",
            //    RequestBody = Request
            //});

            //var response = JsonConvert.DeserializeObject<PersistInvoiceResponse>(daoResponse.data);

            return response;
        }

        public AccountBalanceManager.Contracts.GetInvoiceListResponse GetInvoiceList(GetInvoiceListRequest Request)
        {
            var accountBalanceManagerProxy = IOCManager.Resolve<IAccountBalanceManagerProxy>();
            var response = accountBalanceManagerProxy.GetInvoiceList(Request);

            //var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            //{
            //    Endpoint = @"invoice/list",
            //    RequestBody = Request,
            //    UseServiceUri = true,
            //});

            //var response = JsonConvert.DeserializeObject<GetInvoiceListResponse>(daoResponse.data);

            return response;
        }
    }
}
