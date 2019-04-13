using DebtCollection.ViewModel;
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
    public partial class PaymentHistoryForm : Form
    {
        public ICollection<AccountBalanceManager.Contracts.PaymentHistory> PaymentHistoryList { get; set; }

        public PaymentHistoryForm()
        {
            InitializeComponent();
        }

        public void Execute()
        {
            assignPaymentHistoryListDataTable();
            StyleGridHelper.StyleGrid(dgvPaymentHistory,30);
        }

        private void assignPaymentHistoryListDataTable()
        {
            var dataTable = new DataTable();
            
            dataTable.Columns.Add(Constants.ACCOUNT_ID);
            dataTable.Columns.Add(Constants.SERVICE_ID);
            dataTable.Columns.Add(Constants.PAYMENT_DATE);
            dataTable.Columns.Add(Constants.PAYMENT_MODE);
            dataTable.Columns.Add(Constants.AMOUNT);

            foreach(var paymentHistory in PaymentHistoryList)
            {
                var dataRow = dataTable.NewRow();

                dataRow[Constants.ACCOUNT_ID] = paymentHistory.AccountId;
                dataRow[Constants.SERVICE_ID] = paymentHistory.ServiceId;
                dataRow[Constants.PAYMENT_DATE] = paymentHistory.PaymentDate.ToString("dd/MM/yyyy");
                dataRow[Constants.PAYMENT_MODE] = paymentHistory.PaymentMode;
                dataRow[Constants.AMOUNT] = paymentHistory.Amount;

                dataTable.Rows.Add(dataRow);

            }

            dgvPaymentHistory.DataSource = dataTable;
        }
       
    }
}
