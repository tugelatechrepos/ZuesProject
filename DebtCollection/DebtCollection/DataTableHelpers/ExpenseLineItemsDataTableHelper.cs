using DebtCollection.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.DataTableHelpers
{
    public static class ExpenseLineItemsDataTableHelper
    {
        public static DataTable GetExpenseLineItemsDataTable(ICollection<Expense> ExpenseList)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(Constants.DESCRIPTION);
            dataTable.Columns.Add(Constants.QUANTITY);
            dataTable.Columns.Add(Constants.AMOUNT);
            dataTable.Columns.Add(Constants.VAT);

            if(ExpenseList != null && ExpenseList.Any())
            {
                foreach (var expense in ExpenseList)
                {
                    var dataRow = dataTable.NewRow();
                    dataRow[Constants.DESCRIPTION] = expense.Description;
                    dataRow[Constants.QUANTITY] = expense.Quantity;
                    dataRow[Constants.AMOUNT] = Math.Round(expense.Amount, 2, MidpointRounding.AwayFromZero);
                    dataRow[Constants.VAT] = Math.Round(expense.Vat, 2, MidpointRounding.AwayFromZero);

                    dataTable.Rows.Add(dataRow);
                }

            }
            return dataTable;
        }
    }
}
