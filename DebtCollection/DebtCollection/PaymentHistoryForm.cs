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
        public ICollection<PaymentHistory> PaymentHistoryList { get; set; }

        public PaymentHistoryForm()
        {
            InitializeComponent();
        }

        public void Execute()
        {
            assignPaymentHistoryListDataTable();
            styleGrid(dgvPaymentHistory,30);
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

        private void styleGrid(DataGridView dataGridView, int? ColumnHeight = null)
        {
            dataGridView.BorderStyle = BorderStyle.FixedSingle;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);

            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView.BackgroundColor = Color.White;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.RowTemplate.Height = 20;

            if (ColumnHeight.HasValue)
                dataGridView.ColumnHeadersHeight = ColumnHeight.Value;

            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9F, FontStyle.Bold);

            dataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
    }
}
