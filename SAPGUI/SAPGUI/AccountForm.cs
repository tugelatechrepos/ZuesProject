using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPGUI
{
    public partial class AccountForm : Form//: MetroFramework.Forms.MetroForm
    {
        private ICollection<PaymentHistory> _PaymentHistoryList;

        public AccountForm()
        {
            InitializeComponent();
            assignData();
        }

        private void btnViewPaymentHistory_Click(object sender, EventArgs e)
        {
            var paymentHistoryForm = new PaymentHistoryForm();
            paymentHistoryForm.PaymentHistoryList = _PaymentHistoryList;
            paymentHistoryForm.execute();
            paymentHistoryForm.ShowDialog();
        }

        private void assignData()
        {
            var dbUtility = new PaymentHistoryDBUtility();
            _PaymentHistoryList = dbUtility.GetData(new GetPaymentHistoryListRequest { Skip = 0, Take = 500});
            _PaymentHistoryList = _PaymentHistoryList.OrderBy(x => x.AccountId).ThenByDescending(x => x.PaymentDate).ToList();
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            var accountId = Convert.ToInt32(txtAccountId.Text);
            
            var filteredPaymentHistoryList = _PaymentHistoryList.Where(x => x.AccountId == accountId).ToList();

            filteredPaymentHistoryList = filteredPaymentHistoryList.OrderByDescending(x => x.PaymentDate).ToList();

            var dataTable = DataTableHelper.GetDataTable(filteredPaymentHistoryList);

            dgvAccountPaymentHistory.DataSource = dataTable;

            styleGrid(dgvAccountPaymentHistory, 20);

            dgvAccountPaymentHistory.Visible = true;
        }

        private void styleGrid(DataGridView dataGridView, int? ColumnHeight = null)
        {

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

        private void btnAddPaymentHistory_Click(object sender, EventArgs e)
        {
             assignData();
             var list = _PaymentHistoryList.GroupBy(x => x.AccountId)
                .Select(grp => new { AccountId = grp.Key, value = grp.OrderByDescending(y => y.PaymentDate).Take(5).ToList() }).ToList().SelectMany(z => z.value).ToList();
              
          
            var addUtility = new AddDataUtility();
            var paymentHistoryList = addUtility.Add(list);
            paymentHistoryList = paymentHistoryList.OrderBy(x => x.AccountId).ThenByDescending(x => x.PaymentDate).ToList();
            var frmAddPaymentHistoryPreview = new frmPreviewPaymentHistory();
            frmAddPaymentHistoryPreview.PaymentHistoryList = paymentHistoryList;
            frmAddPaymentHistoryPreview.Execute();
            frmAddPaymentHistoryPreview.ShowDialog();

            assignData();
        }

        private void AccountForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAccountId.Text = "";
            dgvAccountPaymentHistory.DataSource = null;
            dgvAccountPaymentHistory.Visible = false;
        }
    }
}
