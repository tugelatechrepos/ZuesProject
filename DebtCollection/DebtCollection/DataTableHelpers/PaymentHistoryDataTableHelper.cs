using DebtCollection.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.DataTableHelpers
{
    public class PaymentHistoryDataTableHelper
    {
        public static DataTable GetDataTable(ICollection<AccountBalanceManager.Contracts.PaymentHistory> PaymentHistoryList, bool ForReport = false)
        {
            var dataTable = new DataTable();

            if (ForReport)
            {
                dataTable = getDataTableForReport(PaymentHistoryList);
                return dataTable;
            }


           
            dataTable.Columns.Add(Constants.ACCOUNT_ID);
            dataTable.Columns.Add(Constants.SERVICE_ID);
            dataTable.Columns.Add(Constants.SERVICE_NAME);
            dataTable.Columns.Add(Constants.PAYMENT_DATE);
            dataTable.Columns.Add(Constants.PAYMENT_MODE);
            dataTable.Columns.Add(Constants.AMOUNT);


            if (PaymentHistoryList != null && PaymentHistoryList.Any())
            {
                foreach (var paymentHistory in PaymentHistoryList)
                {
                    var dataRow = dataTable.NewRow();
                    dataRow[Constants.ACCOUNT_ID] = paymentHistory.AccountId;
                    dataRow[Constants.SERVICE_ID] = paymentHistory.ServiceId;
                    dataRow[Constants.SERVICE_NAME] = paymentHistory.ServiceName;
                    dataRow[Constants.PAYMENT_DATE] = paymentHistory.PaymentDate;
                    dataRow[Constants.PAYMENT_MODE] = paymentHistory.PaymentMode;
                    dataRow[Constants.AMOUNT] = paymentHistory.Amount;

                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }

        private static DataTable getDataTableForReport(ICollection<AccountBalanceManager.Contracts.PaymentHistory> PaymentHistoryList)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("AccountId");
            dataTable.Columns.Add("ServiceId");
            dataTable.Columns.Add("ServiceName");
            dataTable.Columns.Add("PaymentDate");
            dataTable.Columns.Add("PaymentMode");
            dataTable.Columns.Add("Amount");


            if (PaymentHistoryList != null && PaymentHistoryList.Any())
            {
                foreach (var paymentHistory in PaymentHistoryList)
                {
                    var dataRow = dataTable.NewRow();
                    dataRow["AccountId"] = paymentHistory.AccountId;
                    dataRow["ServiceId"] = paymentHistory.ServiceId;
                    dataRow["ServiceName"] = paymentHistory.ServiceName;
                    dataRow["PaymentDate"] = paymentHistory.PaymentDate.ToString("dd/MM/yyyy");
                    dataRow["PaymentMode"] = paymentHistory.PaymentMode;
                    dataRow["Amount"] = paymentHistory.Amount;

                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }
    }
}
