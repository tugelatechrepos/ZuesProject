using DebtCollection.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtCollection.DataTableHelpers
{
    public static class AccountBalancesDataTableHelper
    {
        public static DataTable GetDataTable(ICollection<AccountBalanceManager.Contracts.AccountBalance> AccountBalanceList)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(Constants.ID);
            dataTable.Columns.Add(Constants.ACCOUNT_ID);
            dataTable.Columns.Add(Constants.OPENING_BALANCE);
            dataTable.Columns.Add(Constants.AOD);
            dataTable.Columns.Add(Constants.TOTAL_PAID);
            dataTable.Columns.Add(Constants.REMAINING_BALANCE);
            dataTable.Columns.Add(Constants.IS_PAYMENT_MISSED);
            dataTable.Columns.Add(Constants.IS_PAYMENT_PARTIAL);
            dataTable.Columns.Add(Constants.OWNER_NAME);
            dataTable.Columns.Add(Constants.ACCOUNT_STATUS);
            

            if(AccountBalanceList != null && AccountBalanceList.Any())
            {
                foreach (var accountBalance in AccountBalanceList)
                {
                    var dataRow = dataTable.NewRow();
                    dataRow[Constants.ID] = accountBalance.Id;
                    dataRow[Constants.ACCOUNT_ID] = accountBalance.AccountId;
                    dataRow[Constants.OPENING_BALANCE] = accountBalance.OpeningBalance;
                    dataRow[Constants.AOD] = accountBalance.PromisedAmount;
                    dataRow[Constants.TOTAL_PAID] = !accountBalance.Paid.HasValue ? "" : $"{accountBalance.Paid.Value}";
                    dataRow[Constants.REMAINING_BALANCE] = !accountBalance.RemainingBalance.HasValue ? "" : $"{accountBalance.RemainingBalance.Value}";
                    dataRow[Constants.IS_PAYMENT_MISSED] = !accountBalance.IsPaymentMissed.HasValue ? "" : $"{accountBalance.IsPaymentMissed.Value}";
                    dataRow[Constants.IS_PAYMENT_PARTIAL] = !accountBalance.IsPartialPayment.HasValue ? "" : $"{accountBalance.IsPartialPayment.Value}";
                    dataRow[Constants.OWNER_NAME] = accountBalance.OwnerName;


                    dataTable.Rows.Add(dataRow);
                }
            }          

            return dataTable;
        }
    }
}
