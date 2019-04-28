using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Client
{
    public interface IDebtCollectionAccessProxy
    {
        GetAccountAODListResponse GetAccountAODList(GetAccountAODListRequest Request);

        DataCleanUpResponse CleanUpData();

        GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request);

        GetAccountIdListResponse GetAccountIdList();

        GetAccountInceptionListResponse GetAccountInceptionList(GetAccountInceptionListRequest Request);

        GetAccountOpeningBalanceListResponse GetAccountOpeningBalanceList(GetAccountOpeningBalanceListRequest Request);

        GetAccountOwnerListResponse GetAccountOwnerList(GetAccountOwnerListRequest Request);

        GetCommissionResponse GetCommission(GetCommissionRequest Request);

        GetInvoiceListResponse GetInvoiceList(GetInvoiceListRequest Request);

        GetPaymentHistoryListResponse GetPaymentHistoryList(GetPaymentHistoryListRequest Request);

        GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request);

        GetTypeTableListResponse GetTypeTableList(GetTypeTableListRequest Request);

        PersistAccountBalanceListResponse PersistAccountBalanceList(PersistAccountBalanceListRequest Request);

        PersistAccountOpeningBalanceListResponse PersistAccountOpeningBalanceList(PersistAccountOpeningBalanceListRequest Request);

        PersistInvoiceResponse PersistInvoice(PersistInvoiceRequest Request);

        PersistPaymentHistoryListResponse PersistPaymentHistoryList(PersistPaymentHistoryListRequest Request);

        PersistPeriodListResponse PersistPeriodList(PersistPeriodListRequest Request);

        PersistPaymentHistoryPayloadListResponse PersistPaymentHistoryPayloadList(PersistPaymentHistoryPayloadListRequest Request);

        PersistPaymentHistoryPayloadPeriodResponse PersistPaymentHistoryPayloadPeriod(PersistPaymentHistoryPayloadPeriodRequest Request);

        GetPaymentHistoryPayloadListResponse GetPaymentHistoryPayloadList(GetPaymentHistoryPayloadListRequest Request);

        GetPaymentHistoryPayloadPeriodResponse GetPaymentHistoryPayloadPeriod(GetPaymentHistoryPayloadPeriodRequest Request);
    }

    public class DebtCollectionAccessProxy : IDebtCollectionAccessProxy
    {
        #region Declarations

        public IGetAccountAODListOperation GetAccountAODListOperation { get; set; }

        public ICleanUpDataOperation CleanUpDataOperation { get; set; }

        public IGetAccountBalanceListOperation GetAccountBalanceListOperation { get; set; }

        public IGetAccountIdListOperation GetAccountIdListOperation { get; set; }

        public IGetAccountInceptionListOperation GetAccountInceptionListOperation { get; set; }

        public IGetAccountOpeningBalanceListOperation GetAccountOpeningBalanceListOperation { get; set; }

        public IGetAccountOwnerListOperation GetAccountOwnerListOperation { get; set; }

        public IGetCommissionOperation GetCommissionOperation { get; set; }

        public IGetInvoiceListOperation GetInvoiceListOperation { get; set; }

        public IGetPaymentHistoryListOperation GetPaymentHistoryListOperation { get; set; }

        public IGetPeriodListOperation GetPeriodListOperation { get; set; }

        public IGetTypeTableListOperation GetTypeTableListOperation { get; set; }

        public IPersistAccountBalanceListOperation PersistAccountBalanceListOperation { get; set; }

        public IPersistAccountOpeningBalanceListOperation PersistAccountOpeningBalanceListOperation { get; set; }

        public IPersistInvoiceOperation PersistInvoiceOperation { get; set; }

        public IPersistPaymentHistoryListOperation PersistPaymentHistoryListOperation { get; set; }

        public IPersistPeriodListOperation PersistPeriodListOperation { get; set; }

        public IPersistPaymentHistoryPayloadListOperation PersistPaymentHistoryPayloadListOperation { get; set; }

        public IPersistPaymentHistoryPayloadPeriodOperation PersistPaymentHistoryPayloadPeriodOperation { get; set; }

        public IGetPaymentHistoryPayloadListOperation GetPaymentHistoryPayloadListOperation { get; set; }

        public IGetPaymentHistoryPayloadPeriodOperation GetPaymentHistoryPayloadPeriodOperation { get; set; }

        #endregion Declarations

        public GetAccountAODListResponse GetAccountAODList(GetAccountAODListRequest Request)
        {
            var response = GetAccountAODListOperation.GetAccountAODList(Request);
            return response;
        }

        public DataCleanUpResponse CleanUpData()
        {
            var response = CleanUpDataOperation.CleanUpData();
            return response;
        }

        public GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request)
        {
            var response = GetAccountBalanceListOperation.GetAccountBalanceList(Request);
            return response;
        }

        public GetAccountIdListResponse GetAccountIdList()
        {
            var response = GetAccountIdListOperation.GetAccountIdList();
            return response;
        }

        public GetAccountInceptionListResponse GetAccountInceptionList(GetAccountInceptionListRequest Request)
        {
            var response = GetAccountInceptionListOperation.GetAccountInceptionList(Request);
            return response;
        }

        public GetAccountOpeningBalanceListResponse GetAccountOpeningBalanceList(GetAccountOpeningBalanceListRequest Request)
        {
            var response = GetAccountOpeningBalanceListOperation.GetAccountOpeningBalanceList(Request);
            return response;
        }

        public GetAccountOwnerListResponse GetAccountOwnerList(GetAccountOwnerListRequest Request)
        {
            var response = GetAccountOwnerListOperation.GetAccountOwnerList(Request);
            return response;
        }

        public GetCommissionResponse GetCommission(GetCommissionRequest Request)
        {
            var response = GetCommissionOperation.GetCommission(Request);
            return response;
        }

        public GetInvoiceListResponse GetInvoiceList(GetInvoiceListRequest Request)
        {
            var response = GetInvoiceListOperation.GetInvoiceList(Request);
            return response;
        }

        public GetPaymentHistoryListResponse GetPaymentHistoryList(GetPaymentHistoryListRequest Request)
        {
            var response = GetPaymentHistoryListOperation.GetPaymentHistoryList(Request);
            return response;
        }

        public GetPeriodListResponse GetPeriodList(GetPeriodListRequest Request)
        {
            var response = GetPeriodListOperation.GetPeriodList(Request);
            return response;
        }

        public GetTypeTableListResponse GetTypeTableList(GetTypeTableListRequest Request)
        {
            var response = GetTypeTableListOperation.GetTypeTableList(Request);
            return response;
        }

        public PersistAccountBalanceListResponse PersistAccountBalanceList(PersistAccountBalanceListRequest Request)
        {
            var response = PersistAccountBalanceListOperation.PersistAccountBalanceList(Request);
            return response;
        }

        public PersistAccountOpeningBalanceListResponse PersistAccountOpeningBalanceList(PersistAccountOpeningBalanceListRequest Request)
        {
            var response = PersistAccountOpeningBalanceListOperation.PersistAccountOpeningBalanceList(Request);
            return response;
        }

        public PersistInvoiceResponse PersistInvoice(PersistInvoiceRequest Request)
        {
            var response = PersistInvoiceOperation.PersistInvoice(Request);
            return response;
        }

        public PersistPaymentHistoryListResponse PersistPaymentHistoryList(PersistPaymentHistoryListRequest Request)
        {
            var response = PersistPaymentHistoryListOperation.PersistPaymentHistoryList(Request);
            return response;
        }

        public PersistPeriodListResponse PersistPeriodList(PersistPeriodListRequest Request)
        {
            var response = PersistPeriodListOperation.PersistPeriodList(Request);
            return response;
        }

        public PersistPaymentHistoryPayloadListResponse PersistPaymentHistoryPayloadList(PersistPaymentHistoryPayloadListRequest Request)
        {
            var response = PersistPaymentHistoryPayloadListOperation.PersistPaymentHistoryPayloadList(Request);
            return response;
        }

        public PersistPaymentHistoryPayloadPeriodResponse PersistPaymentHistoryPayloadPeriod(PersistPaymentHistoryPayloadPeriodRequest Request)
        {
            var response = PersistPaymentHistoryPayloadPeriodOperation.PersistPaymentHistoryPayloadPeriod(Request);
            return response;
        }

        public GetPaymentHistoryPayloadListResponse GetPaymentHistoryPayloadList(GetPaymentHistoryPayloadListRequest Request)
        {
            var response = GetPaymentHistoryPayloadListOperation.GetPaymentHistoryPayloadList(Request);
            return response;
        }

        public GetPaymentHistoryPayloadPeriodResponse GetPaymentHistoryPayloadPeriod(GetPaymentHistoryPayloadPeriodRequest Request)
        {
            var response = GetPaymentHistoryPayloadPeriodOperation.GetPaymentHistoryPayloadPeriod(Request);
            return response;
        }
    }
}
