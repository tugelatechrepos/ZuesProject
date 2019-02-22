using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebtCollection
{

    public class InvoiceDocumentRequest
    {
        public int InvoiceId { get; set; }
        public string CurrentPeriod { get; set; }
        public DataTable InvoiceLineItemDataTable { get; set; }
        public DataTable ExpenseLineItemDataTable { get; set; }
        public string Total { get; set; }
        public string TotalVat { get; set; }
        public string Net { get; set; }
    }

    public partial class InvoiceDocumentForm : Form
    {
       
        public InvoiceDocumentRequest Request { get; set; }

        public InvoiceDocumentForm()
        {
            InitializeComponent();
        }

        public void ExecutePreview()
        {
            
            rptInvoiceDocument.LocalReport.DataSources.Clear();
            var invoiceLineItemDataSource = new ReportDataSource("InvoiceDataPreview", Request.InvoiceLineItemDataTable);

          
            var reportParameterCollection = getReportParameterCollection();

            rptInvoiceDocument.LocalReport.SetParameters(reportParameterCollection);
            rptInvoiceDocument.LocalReport.DataSources.Add(invoiceLineItemDataSource);

            if (Request.ExpenseLineItemDataTable != null && Request.ExpenseLineItemDataTable.Rows != null && Request.ExpenseLineItemDataTable.Rows.Count >= 0)
            {
                var expenseLineItemDataSource = new ReportDataSource("Expense", Request.ExpenseLineItemDataTable);
                rptInvoiceDocument.LocalReport.DataSources.Add(expenseLineItemDataSource);
            }              


            rptInvoiceDocument.LocalReport.Refresh();
            rptInvoiceDocument.RefreshReport();
        }

        private ReportParameterCollection getReportParameterCollection()
        {
            var company = getCompany();
            var customer = getCustomer();

            var parameterList = new ReportParameterCollection();
            parameterList.Add(new ReportParameter("rptFromCompanyName", company.Name));
            parameterList.Add(new ReportParameter("rptFromAddress", company.Address));
            parameterList.Add(new ReportParameter("rptFromPhoneNumber", company.PhoneNumber));
            parameterList.Add(new ReportParameter("rptFromZip", company.ZipCode));
            parameterList.Add(new ReportParameter("rptFromEmail", company.Email));

            parameterList.Add(new ReportParameter("rptToCompanyName", customer.Name));
            parameterList.Add(new ReportParameter("rptToAddress", customer.Address));
            parameterList.Add(new ReportParameter("rptToPhoneNumber", customer.PhoneNumber));
            parameterList.Add(new ReportParameter("rptToZip", customer.ZipCode));
            parameterList.Add(new ReportParameter("rptToEmail", customer.Email));
            

            parameterList.Add(new ReportParameter("rptInvoiceDate", DateTime.Now.ToString("dd/MMM/yyyy")));
            parameterList.Add(new ReportParameter("rptInvoiceId", Convert.ToString(Request.InvoiceId)));
            parameterList.Add(new ReportParameter("rptCurrentPeriod", Request.CurrentPeriod));
            parameterList.Add(new ReportParameter("rptTotal", Request.Total));
            parameterList.Add(new ReportParameter("rptVAT", Request.TotalVat));
            parameterList.Add(new ReportParameter("rptNet", Request.Net));

            return parameterList;
        }

        private Company getCompany()
        {
            var company = new Company
            {
                Name = "ABC Collection Panel",
                //Address = "212 Lane Toronto",
                Address = "289 Lane COJ, muhaou@COJ.com\n(+78) 4568923\n22222289",
                Email = "miami@abcgroup.com",
                PhoneNumber = "(+78) 34522238",
                ZipCode = "6589043"
            };
            return company;
        }

        private Company getCustomer()
        {
            var customer = new Company
            {
                Name = "City of Johannesburg Muni. Corp",
                Address = "289 Lane COJ, muhaou@COJ.com\n(+78) 4568923\n22222289",
                Email = "muhaou@COJ.com",
                PhoneNumber = "(+78) 4568923",
                ZipCode = "22222289"
            };
            return customer;
        }

       
    }
}
