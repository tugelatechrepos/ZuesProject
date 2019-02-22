using DebtCollection.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.DataTableHelpers
{
    public static class InvoiceLineItemsDataTableHelper
    {
        public static DataTable GetInvoiceLineItemsDataTable(ICollection<InvoiceDataPreview> InvoiceDataPreviewList)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(Constants.DESCRIPTION);
            dataTable.Columns.Add(Constants.QUANTITY);
            dataTable.Columns.Add(Constants.AMOUNT);
            dataTable.Columns.Add(Constants.COMMISSION_PERCENTAGE);

            if(InvoiceDataPreviewList != null && InvoiceDataPreviewList.Any())
            {
                foreach (var invoicePreview in InvoiceDataPreviewList)
                {
                    var dataRow = dataTable.NewRow();
                    dataRow[Constants.DESCRIPTION] = invoicePreview.Description;
                    dataRow[Constants.QUANTITY] = invoicePreview.Quantity;
                    dataRow[Constants.AMOUNT] = Math.Round(invoicePreview.Amount, 2, MidpointRounding.AwayFromZero);
                    dataRow[Constants.COMMISSION_PERCENTAGE] = Math.Round(invoicePreview.Commission, 2, MidpointRounding.AwayFromZero);

                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }
    }
}
