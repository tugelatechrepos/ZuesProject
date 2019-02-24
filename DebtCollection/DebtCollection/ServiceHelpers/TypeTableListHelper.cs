using DebtCollectionAccess.Client;
using DebtCollectionAccess.Contracts;
using ProjectCoreLibrary;

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
            var accessProxy = IOCManager.Resolve<IDebtCollectionAccessProxy>();
            var response = accessProxy.GetTypeTableList(Request);

            //var daoResponse = DaoHelper.Execute(new DaoHelperRequest
            //{
            //    Endpoint = @"TableType/list",
            //    RequestBody = Request
            //});

            //var response = JsonConvert.DeserializeObject<GetTypeTableListResponse>(daoResponse.data);

            return response;
        }
    }
}
