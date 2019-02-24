using AccountBalanceManager.Contracts;
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
    public partial class frmPreviewPaymentHistory : MetroFramework.Forms.MetroForm
    {
        public ICollection<PaymentHistory> PaymentHistoryList { get; set; }

        public frmPreviewPaymentHistory()
        {
            InitializeComponent();
        }

        public void Execute()
        {
            var dataTable = DataTableHelper.GetDataTable(PaymentHistoryList);
            dgvPaymentHistoryPreview.DataSource = dataTable;
            GridStyleHelper.StyleGrid(dgvPaymentHistoryPreview);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!bgAddPaymentHistory.IsBusy)
            {
                pnlAddPaymentHistory.Visible = true;
                bgAddPaymentHistory.RunWorkerAsync();
            }
        }

        private void bgAddPaymentHistory_DoWork(object sender, DoWorkEventArgs e)
        {
            var utilty = new PaymentHistoryDBUtility();

            var paymentHistoryList = PaymentHistoryList.Select(x => new DebtCollectionAccess.PaymentHistory
            {
                Id = x.Id,
                AccountId = x.AccountId,
                Amount = x.Amount,
                InvoiceId = x.InvoiceId,
                PaymentDate = x.PaymentDate,
                PaymentMode = x.PaymentMode,
                ServiceId = x.ServiceId
            }).ToList();

            utilty.PersistData(paymentHistoryList);
            AcccountBalanceUtility.RegisterAccountBalances();
        }

        private void bgAddPaymentHistory_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pnlAddPaymentHistory.Visible = false;
            MessageBox.Show("Data Saved Successfully", "Add Payment History", MessageBoxButtons.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
