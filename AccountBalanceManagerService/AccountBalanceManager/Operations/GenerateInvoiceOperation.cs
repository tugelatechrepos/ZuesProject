using AccountBalanceManager.Contracts;
using AccountBalanceManagerService.Processor;
using ProjectCoreLibrary;

namespace AccountBalanceManager.Operations
{
    public interface IGenerateInvoiceOperation
    {
        GenerateInvoiceResponse GenerateInvoice();
    }

    public class GenerateInvoiceOperation : IGenerateInvoiceOperation
    {
        #region Declarations

        private GenerateInvoiceResponse _Response;

        public IGenerateInvoiceProcessor GenerateInvoiceProcessor { get; set; }

        #endregion Declarations

        public GenerateInvoiceResponse GenerateInvoice()
        {
            _Response = new GenerateInvoiceResponse { ValidationResults = new ValidationResults() };

            generate();

            return _Response;
        }

        private void generate()
        {
            var response = GenerateInvoiceProcessor.GenerateInvoice();
            _Response.InvoiceId = response.InvoiceId;
            _Response.ValidationResults = response.ValidationResults;
        }
    }
}
