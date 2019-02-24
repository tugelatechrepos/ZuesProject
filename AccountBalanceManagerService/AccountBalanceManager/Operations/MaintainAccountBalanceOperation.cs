using AccountBalanceManager.Contracts;
using AccountBalanceManagerService.Processor;
using ProjectCoreLibrary;

namespace AccountBalanceManager.Operations
{
    public interface IMaintainAccountBalanceOperation
    {
        MaintainAccountBalanceResponse MaintainAccountBalance();
    }

    public class MaintainAccountBalanceOperation : IMaintainAccountBalanceOperation
    {
        #region Declarations

        private MaintainAccountBalanceResponse _Response;

        public IAccountBalanceCalculationProcessor AccountBalanceCalculationProcessor { get; set; }

        #endregion Declarations

        public MaintainAccountBalanceResponse MaintainAccountBalance()
        {
            _Response = new MaintainAccountBalanceResponse { ValidationResults = new ValidationResults() };
            var response = AccountBalanceCalculationProcessor.ProcessAccountBalanceList(new AccountBalanceCalculationProcessorRequest());
            _Response.ValidationResults = response.ValidationResults;

            return _Response;
        }
    }
}
