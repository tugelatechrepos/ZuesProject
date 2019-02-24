using AccountBalanceManager.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPGUI
{
    public class DataTableHelper
    {
        public static DataTable GetDataTable(ICollection<PaymentHistory> PaymentHistoryList)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Account Id");
            dataTable.Columns.Add("Service Id");
            dataTable.Columns.Add("Service Name");
            dataTable.Columns.Add("Payment Date");
            dataTable.Columns.Add("Mode of Payment");
            dataTable.Columns.Add("Amount");


            if (PaymentHistoryList != null && PaymentHistoryList.Any())
            {
                foreach (var paymentHistory in PaymentHistoryList)
                {
                    var dataRow = dataTable.NewRow();
                    dataRow["Account Id"] = paymentHistory.AccountId;
                    dataRow["Service Id"] = paymentHistory.ServiceId;
                    dataRow["Service Name"] = paymentHistory.ServiceName;
                    dataRow["Payment Date"] = paymentHistory.PaymentDate.ToString("dd/MM/yyyy");
                    dataRow["Mode of Payment"] = paymentHistory.PaymentMode;
                    dataRow["Amount"] = paymentHistory.Amount;

                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }
    }
}
