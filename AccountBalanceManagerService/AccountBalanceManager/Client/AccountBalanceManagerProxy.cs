using AccountBalanceManager.Operations;
using AccountBalanceManager.Contracts;
using DebtCollectionAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalanceManager.Client
{
    public interface IAccountBalanceManagerProxy
    {
        Operations.GetPaymentHistoryListResponse GetPaymentHistoryList(GetPaymentHistoryListRequest Request);

        MaintainAccountBalanceResponse MaintainAccountBalance(MaintainAccountBalanceRequest Request);

        Operations.GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request);

        GenerateInvoiceResponse GenerateInvoice(GenerateInvoiceRequest Request);

        Contracts.GetInvoiceListResponse GetInvoiceList(GetInvoiceListRequest Request);

        GetPeriodDetailListResponse GetPeriodDetailList(GetPeriodDetailListRequest Request);
    }

    public class AccountBalanceManagerProxy : IAccountBalanceManagerProxy
    {
        #region Declarations

        public IGetPaymentHistoryListOperation GetPaymentHistoryListOperation { get; set; }

        public IMaintainAccountBalanceOperation MaintainAccountBalanceOperation { get; set; }

        public IGetAccountBalanceListOperation GetAccountBalanceListOperation { get; set; }

        public IGenerateInvoiceOperation GenerateInvoiceOperation { get; set; }

        public IGetInvoiceListOperation GetInvoiceListOperation { get; set; }

        public IGetPeriodDetailListOperation GetPeriodDetailListOperation { get; set; }

        #endregion Declarations

        public Operations.GetPaymentHistoryListResponse GetPaymentHistoryList(GetPaymentHistoryListRequest Request)
        {
            var response = GetPaymentHistoryListOperation.GetPaymentHistoryList(Request);
            return response;
        }

        public MaintainAccountBalanceResponse MaintainAccountBalance(MaintainAccountBalanceRequest Request)
        {
            var response = MaintainAccountBalanceOperation.MaintainAccountBalance(Request);
            return response;
        }

        public Operations.GetAccountBalanceListResponse GetAccountBalanceList(GetAccountBalanceListRequest Request)
        {
            var response = GetAccountBalanceListOperation.GetAccountBalanceList(Request);
            return response;
        }

        public GenerateInvoiceResponse GenerateInvoice(GenerateInvoiceRequest Request)
        {
            var response = GenerateInvoiceOperation.GenerateInvoice(Request);
            return response;
        }

        public Contracts.GetInvoiceListResponse GetInvoiceList(GetInvoiceListRequest Request)
        {
            var response = GetInvoiceListOperation.GetInvoiceList(Request);
            return response;
        }

        public GetPeriodDetailListResponse GetPeriodDetailList(GetPeriodDetailListRequest Request)
        {
            var response = GetPeriodDetailListOperation.GetPeriodDetailList(Request);
            return response;
        }
    }
}
