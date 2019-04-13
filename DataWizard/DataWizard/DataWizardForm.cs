using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Operations;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataWizard
{
    public partial class frmDataWizard : MetroFramework.Forms.MetroForm
    {
        private bool _IsDataPresent;
        private const int COMPANY_ID = 3;

        public frmDataWizard()
        {
            InitializeComponent();
            assignIsDataPresent();
            enableDisableButtons();
        }

        private void assignIsDataPresent()
        {
            var paymentHistoryList = PaymentHistoryDBUtility.GetData(new GetPaymentHistoryListRequest
            {
                Skip = 0,
                Take = 1,
                CompanyId = COMPANY_ID
            });

            _IsDataPresent = (paymentHistoryList != null && paymentHistoryList.Any());
        }

        private void enableDisableButtons()
        {
            btnSetUp.Enabled = !_IsDataPresent;
            btnCleanUp.Enabled = _IsDataPresent;
        }

        private void btnSetUp_Click(object sender, EventArgs e)
        {
            if (!bgSetUp.IsBusy)
            {
                pnlSpinner.Visible = true;
                lblSpinner.Text = "Setting up data..Please wait";
                bgSetUp.RunWorkerAsync();
            }            
        }

        private void bgSetUp_DoWork(object sender, DoWorkEventArgs e)
        {
            var initializeSeed = new InitializeSeed();
            initializeSeed.Initialize();           
        }

        private void bgSetUp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pnlSpinner.Visible = false;
            lblSpinner.Text = "";
            lblStatus.Visible = true;
            lblStatus.Text = "Set up done successfully..";
        }

        private void btnCleanUp_Click(object sender, EventArgs e)
        {
            if (!bgCleanUp.IsBusy)
            {
                pnlSpinner.Visible = true;
                lblSpinner.Text = "Cleaning up data..Please wait";
                bgCleanUp.RunWorkerAsync();
            }
        }

        private void bgCleanUp_DoWork(object sender, DoWorkEventArgs e)
        {
            DataCleanUpUtility.CleanUp();
        }

        private void bgCleanUp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pnlSpinner.Visible = false;
            lblSpinner.Text = "";
            lblStatus.Visible = true;
            lblStatus.Text = "Clean up done successfully..";
        }       
    }
}
