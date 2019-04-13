using AccountBalanceManager.Contracts;
using AccountBalanceManagerService.Processor;
using ProjectCoreLibrary;

namespace AccountBalanceManager.Operations
{
    public interface IGenerateInvoiceOperation
    {
        GenerateInvoiceResponse GenerateInvoice(GenerateInvoiceRequest Request);
    }

    public class GenerateInvoiceOperation : IGenerateInvoiceOperation
    {
        #region Declarations

        private GenerateInvoiceRequest _Request;

        private GenerateInvoiceResponse _Response;

        public IGenerateInvoiceProcessor GenerateInvoiceProcessor { get; set; }

        #endregion Declarations

        public GenerateInvoiceResponse GenerateInvoice(GenerateInvoiceRequest Request)
        {
            _Request = Request;
            _Response = new GenerateInvoiceResponse { ValidationResults = new ValidationResults() };

            generate();

            return _Response;
        }

        private void generate()
        {
            var response = GenerateInvoiceProcessor.GenerateInvoice(new GenerateInvoiceProcessorRequest
            {
                PeriodId = _Request.PeriodId,
                CompanyId = _Request.CompanyId,
            });

            _Response.InvoiceId = response.InvoiceId;
            _Response.ValidationResults = response.ValidationResults;
        }
    }
}
