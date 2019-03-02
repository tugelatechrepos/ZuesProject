using AccountBalanceManager.Contracts;
using DebtCollectionAccess.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPGUI
{
    public partial class SAPGUILoginForm : Form//: MetroFramework.Forms.MetroForm
    {
        private ICollection<PaymentHistory> _PaymentHistoryList;

        public SAPGUILoginForm()
        {
            InitializeComponent();
            this.ActiveControl = txtUserName;
            this.Focus();          
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
           
            if (!validate()) return;
            loadSAP();                     
        }

        private void loadSAP()
        {
            if (!bgSAPLoad.IsBusy)
            {
                pnlSAPLoading.Visible = true;
                bgSAPLoad.RunWorkerAsync();
            }
        }

        private bool validate()
        {
            var userName = txtUserName.Text;
            var password = txtPassword.Text;
            
            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username or password cannot be empty", "Validation", MessageBoxButtons.OK);
                return false;
            }

            if (!string.Equals(userName, "letsholo.thipe"))
            {
                MessageBox.Show("Incorrect Username or password", "Validation", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void bgSAPLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            var dbUtility = new PaymentHistoryDBUtility();
            _PaymentHistoryList = dbUtility.GetData(new GetPaymentHistoryListRequest { Skip = 0, Take = 500 });
            _PaymentHistoryList = _PaymentHistoryList?.OrderBy(x => x.AccountId).ThenByDescending(x=>x.PaymentDate).ToList();
        }

        private void bgSAPLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pnlSAPLoading.Visible = false;
            var accountform = new AccountForm();
            accountform.PaymentHistoryList = _PaymentHistoryList;
            this.Hide();
            accountform.ShowDialog();
        }
    }
}
