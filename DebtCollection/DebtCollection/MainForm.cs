using MaterialSkin;
using MaterialSkin.Controls;
using System;
using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DebtCollection.ViewModel;
using DebtCollection.ServiceHelpers;
using DebtCollection.Core;
using DebtCollection.DataTableHelpers;
using AccountBalanceManager.Enum;

namespace DebtCollection
{

    public partial class MainForm : MaterialForm
    {
        #region Declarations

        private ICollection<DebtCollectionAccess.Period> _PeriodList;
        private List<int> _AccountIdList;
        private DebtCollectionAccess.Period _CurrentPeriod;
        private DebtCollectionAccess.Period _PreviousPeriod;
        private ICollection<AccountBalanceManager.Contracts.PeriodDetail> _PeriodReadinessDetailList;
        private const int COMPANY_ID = 3;

        public IPeriodHelper Periodhelper { get; set; }
        public IInvoiceHelper InvoiceHelper { get; set; }
        public IPaymentHistoryHelper PaymentHistoryHelper { get; set; }
        public ITypeTableListHelper TypeTableListHelper { get; set; }
        public ICommissionHelper CommissionHelper { get; set; }
        public IAccountBalanceHelper AccountBalanceHelper { get; set; }

        #endregion Declarations

        public MainForm()
        {
            InitializeComponent();
            initializeHelpers();
            var skinManager = MaterialSkinManager.Instance;            

            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(
            Primary.BlueGrey100, Primary.BlueGrey200, Primary.BlueGrey400,
            Accent.Blue400, TextShade.BLACK);

            materialTabSelector1.BaseTabControl.TabPages.Remove(tabGenerateInvoice);
            materialTabSelector1.BaseTabControl.TabPages.Remove(tabInvoices);

            materialTabSelector1.Width = 380;

            //materialTabSelector1.Width = 560;
            for (int i = 0; i < materialTabSelector1.BaseTabControl.TabPages.Count; i++)
            {
                materialTabSelector1.BaseTabControl.TabPages[i].TabIndex = i;
            }
        }

        private void initializeHelpers()
        {
            Periodhelper = IOCManager.Resolve<IPeriodHelper>();
            InvoiceHelper = IOCManager.Resolve<IInvoiceHelper>();
            PaymentHistoryHelper = IOCManager.Resolve<IPaymentHistoryHelper>();
            TypeTableListHelper = IOCManager.Resolve<ITypeTableListHelper>();
            CommissionHelper = IOCManager.Resolve<ICommissionHelper>();
            AccountBalanceHelper = IOCManager.Resolve<IAccountBalanceHelper>();            
        }     

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadPeriodList();
            assignAccountIdList();
            styleGrids();
        }
        
        private void styleGrids()
        {
            StyleGridHelper.StyleGrid(dgvPeriodDetail);
            StyleGridHelper.StyleGrid(dgvAccountBalance,30);
        }

        private void assignCurrentPeriod()
        {
            if (_PeriodList == null || !_PeriodList.Any()) return;

            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            var period = _PeriodList.FirstOrDefault(x => (x.FromDate.Month == currentMonth && x.ToDate.Month == currentMonth)

                                      && (x.FromDate.Year == currentYear && x.ToDate.Year == currentYear));

            _CurrentPeriod = period;

            _PreviousPeriod = _PeriodList.Where(x => x.ToDate < _CurrentPeriod.FromDate)?.OrderByDescending(x => x.ToDate)?.FirstOrDefault();
        }

        private void loadPeriodList()
        {
            if (!periodLoadBackgroundWorker.IsBusy)
            {
                pbPeriodDetailLoading.Visible = true;
                periodLoadBackgroundWorker.RunWorkerAsync();
            }
        }

        private void periodLoadBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var response = Periodhelper.GetPeriodList(new DebtCollectionAccess.Contracts.GetPeriodListRequest { CompanyId = COMPANY_ID });
            _PeriodList = response.PeriodList;

            assignPeriodReadinessDetail();
        }
      
        private void btnReloadPeriod_Click(object sender, EventArgs e)
        {
            if (!periodLoadBackgroundWorker.IsBusy)
            {
                pbPeriodDetailLoading.Visible = true;
                pbPeriodDetailLoading.Visible = true;
                periodLoadBackgroundWorker.RunWorkerAsync();
            }
        }

        private void periodLoadBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbPeriodDetailLoading.Visible = false;

            if (_PeriodList == null || !_PeriodList.Any()) return;

            var periodList = _PeriodList;

            cmbSelectAbPeriod.DataSource = periodList;
            cmbSelectAbPeriod.DisplayMember = "Name";
            cmbSelectAbPeriod.ValueMember = "Id";

            assignCurrentPeriod();
            bindDataToPeriodDetailGrid();
        }

        private void bindDataToPeriodDetailGrid()
        {
            if (_PeriodReadinessDetailList == null || !_PeriodReadinessDetailList.Any()) {  return; }

            pnlLegend.Visible = true;           
            dgvPeriodDetail.Visible = true;

            dgvPeriodDetail.Columns.Clear();
            var dataTable = PeriodDetailDataTableHelper.GetDataTable(_PeriodReadinessDetailList);
            dgvPeriodDetail.DataSource = dataTable;
            var btn = new DataGridViewButtonColumn();
            btn.HeaderText = Constants.INVOICE_BUTTON;
            btn.Text = "Preview Invoice";
            btn.Name = "PreviewInvoice";
            btn.UseColumnTextForButtonValue = true;
            dgvPeriodDetail.Columns.Add(btn);           
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tabControl = sender as MaterialTabControl;
            var selectedTabName = tabControl.SelectedTab.Name;

            switch (selectedTabName)
            {
                case "tabGenerateInvoice":
                    //var periodList = _PeriodList;
                    //cmbSelectPeriod.DataSource = periodList;
                    //cmbSelectPeriod.DisplayMember = "Description";
                    //cmbSelectPeriod.ValueMember = "Id";
                    break;

                case "tabPaymentHistory":
                    //assignAccountIdList();
                    break;

                case "tabInvoices":
                    
                    break;

                case "tabAccountBalance":
                    cmbSelectAbPeriod_SelectedIndexChanged(null, null);
                    break;
            }
        }      

        private void btnGetActuals_Click(object sender, EventArgs e)
        {
            int AccountId;
            int? AccountIdValue = null;
            var accountIdValue = Convert.ToString(cmbAccountId.SelectedValue);

            if (accountIdValue != "--All--")
            {
                if (Int32.TryParse(accountIdValue, out AccountId))
                {
                    AccountIdValue = AccountId;
                }
            }

            var fromDate = dtpActualFromDate.Value;
            var toDate = dtpActualToDate.Value;

            var paymentHistoryListResponse = PaymentHistoryHelper.GetPaymentHistoryList(new DebtCollectionAccess.Contracts.GetPaymentHistoryListRequest
            {
                AccountIdList = (AccountIdValue.HasValue && AccountIdValue != 0) ? new List<int> { AccountIdValue.Value } : null,
                FromDate = fromDate,
                ToDate = toDate,
                CompanyId = COMPANY_ID
            });       

            if (paymentHistoryListResponse.PaymentHistoryList == null || !paymentHistoryListResponse.PaymentHistoryList.Any())
            { MessageBox.Show("No Actuals found for this date", "Payment List", MessageBoxButtons.OK); rptPaymentHistoy.Visible = false; return; }

            var paymentHistoryList = paymentHistoryListResponse.PaymentHistoryList.OrderBy(x => x.AccountId).ThenByDescending(x => x.PaymentDate).ToList();

            var paymentHistoryDataTable = PaymentHistoryDataTableHelper.GetDataTable(paymentHistoryList, true);
            rptPaymentHistoy.Visible = true;
            rptPaymentHistoy.LocalReport.DataSources.Clear();
            var paymentHistoryDataSource = new ReportDataSource("PaymentHistory", paymentHistoryDataTable);
            rptPaymentHistoy.LocalReport.DataSources.Add(paymentHistoryDataSource);
            rptPaymentHistoy.LocalReport.ReportEmbeddedResource = "DebtCollection.PaymentHistoryReport.rdlc";
            rptPaymentHistoy.LocalReport.Refresh();
            rptPaymentHistoy.RefreshReport();
        }

        private void assignAccountIdList()
        {
            if (!accountIdListbgWorker.IsBusy)
            {
                accountIdListbgWorker.RunWorkerAsync();
            }
        }

        private void accountIdListbgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var response = PaymentHistoryHelper.GetAccountIdList(new DebtCollectionAccess.Contracts.GetAccountIdListRequest());
            _AccountIdList = response.AccountIdList.ToList();
        }

        private void accountIdListbgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_AccountIdList == null || !_AccountIdList.Any()) return;


            var itemList = new List<string> { "--All--" };

            var accountIdListString = _AccountIdList.Select(x => Convert.ToString(x));

            itemList.AddRange(accountIdListString);

            cmbAccountId.DataSource = itemList;
        }     

        private void cmbSelectAbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            int periodId = 0;
            if (!Int32.TryParse(Convert.ToString(cmbSelectAbPeriod.SelectedValue), out periodId)) return;

            var response = AccountBalanceHelper.GetAccountBalanceList(new DebtCollectionAccess.Contracts.GetAccountBalanceListRequest
            {
                PeriodIdList = new List<int> { periodId },
                CompanyId = COMPANY_ID,
                StatusIdList = new List<int> { (int)AccountBalanceStatusEnum.None , (int)AccountBalanceStatusEnum.IsPartialPayment , (int)AccountBalanceStatusEnum.IsPaymentMissed, (int)AccountBalanceStatusEnum.IsFullyPaid}
            });
        
            if (response.AccountBalanceList == null || !response.AccountBalanceList.Any()) return;

            pnlAccountBalanceStatus.Visible = true;
            dgvAccountBalance.Visible = true;
            var accountBalanceList = response.AccountBalanceList.OrderBy(x => x.AccountId).ToList();

            var dataTable = AccountBalancesDataTableHelper.GetDataTable(accountBalanceList);
            dgvAccountBalance.DataSource = dataTable;
        }

        private void assignPeriodReadinessDetail()
        {
            if (_PeriodList == null || !_PeriodList.Any()) return;

            var response = Periodhelper.GetPeriodDetail(new AccountBalanceManager.Contracts.GetPeriodDetailListRequest { CompanyId = COMPANY_ID});

           _PeriodReadinessDetailList = response.PeriodDetailList;            
        }

        private void dgvAccountBalance_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var selectedRow = dgvAccountBalance.Rows[e.RowIndex];
            var accountId = Convert.ToInt32(selectedRow.Cells[Constants.ACCOUNT_ID].Value);

            int periodId = 0;
            if (!Int32.TryParse(Convert.ToString(cmbSelectAbPeriod.SelectedValue), out periodId)) return;

            var period = _PeriodList.FirstOrDefault(x => x.Id == periodId);

            var response = PaymentHistoryHelper.GetPaymentHistoryList(new DebtCollectionAccess.Contracts.GetPaymentHistoryListRequest
            {
                AccountIdList = new List<int> { accountId },
                FromDate = period.FromDate,
                ToDate = period.ToDate,
                CompanyId = COMPANY_ID
            });

            var paymentHistoryList = response.PaymentHistoryList;

            if (paymentHistoryList == null || !paymentHistoryList.Any()) return;

            paymentHistoryList = paymentHistoryList.OrderByDescending(x => x.PaymentDate).ToList();

            using (var paymentHistoryForm = new PaymentHistoryForm())
            {
                paymentHistoryForm.PaymentHistoryList = paymentHistoryList;
                paymentHistoryForm.Execute();

                paymentHistoryForm.ShowDialog();
            }
        }

        private void dgvAccountBalance_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            dgvAccountBalance.Columns[Constants.ID].Visible = false;
            dgvAccountBalance.Columns[Constants.OWNER_NAME].Visible = false;

            foreach (DataGridViewRow row in dgvAccountBalance.Rows)
            {
                var isPaymentMissedCell = Convert.ToString(row.Cells[Constants.IS_PAYMENT_MISSED].Value);
                var isPartialPaymentCell = Convert.ToString(row.Cells[Constants.IS_PAYMENT_PARTIAL].Value);
                var isRemainingBalanceCell = row.Cells[Constants.REMAINING_BALANCE].Value != DBNull.Value ? Convert.ToDecimal(row.Cells[Constants.REMAINING_BALANCE].Value) : (decimal?)null;
                var totalPaid = row.Cells[Constants.TOTAL_PAID].Value != DBNull.Value ? Convert.ToDecimal(row.Cells[Constants.TOTAL_PAID].Value) : (decimal?)null;
                var AOD = row.Cells[Constants.AOD].Value != DBNull.Value ? Convert.ToDecimal(row.Cells[Constants.AOD].Value) : (decimal?)null;


                var isPaymentMissed = string.IsNullOrEmpty(isPaymentMissedCell) ? (bool?)null : Convert.ToBoolean(isPaymentMissedCell) ? true : false;
                var isPartialPayment = string.IsNullOrEmpty(isPartialPaymentCell) ? (bool?)null : Convert.ToBoolean(isPartialPaymentCell) ? true : false;


                if (isPaymentMissed.HasValue && isPaymentMissed.Value)
                {
                    row.Cells[Constants.ACCOUNT_STATUS].Style.BackColor = (Color)new ColorConverter().ConvertFromString("#cc3232");
                    continue;
                }

                if (isPartialPayment.HasValue && isPartialPayment.Value)
                {
                    row.Cells[Constants.ACCOUNT_STATUS].Style.BackColor = (Color)new ColorConverter().ConvertFromString("#e7b416");
                    continue;
                }

                if (isRemainingBalanceCell == 0.0M  ||  (totalPaid >= AOD))
                {
                    row.Cells[Constants.ACCOUNT_STATUS].Style.BackColor = (Color)new ColorConverter().ConvertFromString("#2dc937");
                    continue;
                }

               // row.Cells[Constants.ACCOUNT_STATUS].Style.BackColor = Color.LightGreen;

            }

            dgvAccountBalance.Columns[Constants.IS_PAYMENT_MISSED].Visible = false;
            dgvAccountBalance.Columns[Constants.IS_PAYMENT_PARTIAL].Visible = false;
            //dgvAccountBalance.Columns[Constants.OWNER_ID].Visible = false;

        }

        private void dgvPeriodDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvPeriodDetail.Rows == null || dgvPeriodDetail.Rows.Count == 0) return;

            dgvPeriodDetail.Columns[Constants.PERIOD_ID].Visible = false;

            foreach (DataGridViewRow row in dgvPeriodDetail.Rows)
            {
                bool readiness = Convert.ToString(row.Cells[Constants.TARGET_METRIC].Value) == "Yes" ? true : false;

                row.Cells[Constants.TARGET_METRIC].Style.BackColor = readiness ? (Color)new ColorConverter().ConvertFromString("#2dc937") : (Color)new ColorConverter().ConvertFromString("#cc3232");
            }

           
        }

        private void dgvPeriodDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == dgvPeriodDetail.Columns["PreviewInvoice"].Index)
            {
                var periodId = Convert.ToInt32(dgvPeriodDetail[Constants.PERIOD_ID, e.RowIndex].Value);

                if(periodId == _CurrentPeriod.Id)
                {
                    MessageBox.Show("You cannot preview Invoice for Current Period","Generate Invoice",MessageBoxButtons.OK);
                    return;
                }

                var invoiceForm = new frmInvoice();
                invoiceForm.PeriodId = periodId;
                invoiceForm.PeriodHelper = Periodhelper;
                invoiceForm.InvoiceHelper = InvoiceHelper;
                invoiceForm.CompanyId = COMPANY_ID;
                invoiceForm.Execute();
                invoiceForm.ShowDialog();
            }
        }
    }
}


