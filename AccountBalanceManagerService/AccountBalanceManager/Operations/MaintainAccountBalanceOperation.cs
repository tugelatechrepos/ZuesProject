using AccountBalanceManager.Contracts;
using AccountBalanceManagerService.Processor;
using ProjectCoreLibrary;

namespace AccountBalanceManager.Operations
{
    public interface IMaintainAccountBalanceOperation
    {
        MaintainAccountBalanceResponse MaintainAccountBalance(MaintainAccountBalanceRequest Request);
    }

    public class MaintainAccountBalanceOperation : IMaintainAccountBalanceOperation
    {
        #region Declarations

        private MaintainAccountBalanceRequest _Request;
        private MaintainAccountBalanceResponse _Response;

        public IAccountBalanceCalculationProcessor AccountBalanceCalculationProcessor { get; set; }

        #endregion Declarations

        public MaintainAccountBalanceResponse MaintainAccountBalance(MaintainAccountBalanceRequest Request)
        {
            _Request = Request;
            _Response = new MaintainAccountBalanceResponse { ValidationResults = new ValidationResults() };

            var response = AccountBalanceCalculationProcessor.ProcessAccountBalanceList(new AccountBalanceCalculationProcessorRequest { CompanyId = _Request.CompanyId});
            _Response.ValidationResults = response.ValidationResults;

            return _Response;
        }
    }
}
