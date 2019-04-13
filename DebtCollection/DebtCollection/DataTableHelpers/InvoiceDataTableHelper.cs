using DebtCollection.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.DataTableHelpers
{
    public static class InvoiceDataTableHelper
    {
        public static DataTable GetInvoiceDataTable(ICollection<InvoiceDataForGrid> InvoiceList)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(Constants.ID);
            dataTable.Columns.Add(Constants.DATE);
            dataTable.Columns.Add(Constants.OPENING_BALANCE);
            dataTable.Columns.Add(Constants.TOTAL_PAID);
            dataTable.Columns.Add(Constants.YIELD_PERCENTAGE);
            dataTable.Columns.Add(Constants.COMMISSION_PERCENTAGE);
            dataTable.Columns.Add(Constants.INVOICE_TOTAL);

            if(InvoiceList != null && InvoiceList.Any())
            {
                foreach (var invoice in InvoiceList)
                {
                    var dataRow = dataTable.NewRow();
                    dataRow[Constants.ID] = invoice.Id;
                    dataRow[Constants.DATE] = invoice.Date.ToString("dd/MM/yyyy");
                    dataRow[Constants.OPENING_BALANCE] = Math.Round(invoice.TotalOpeningBalance, 2, MidpointRounding.AwayFromZero);
                    dataRow[Constants.TOTAL_PAID] = Math.Round(invoice.TotalPaid, 2, MidpointRounding.AwayFromZero);
                    dataRow[Constants.YIELD_PERCENTAGE] = invoice.YieldPercentage;
                    dataRow[Constants.COMMISSION_PERCENTAGE] = $"{ Math.Round(invoice.CommisionOnYield, 2, MidpointRounding.AwayFromZero)}";
                    dataRow[Constants.INVOICE_TOTAL] = Math.Round(invoice.InvoiceTotal, 2, MidpointRounding.AwayFromZero);

                    dataTable.Rows.Add(dataRow);
                }
            }          

            return dataTable;
        }
    }
}
