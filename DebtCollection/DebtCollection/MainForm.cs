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

namespace DebtCollection
{

    public partial class MainForm : MaterialForm
    {
        #region Declarations

        private ICollection<DebtCollectionAccess.Period> _PeriodList;
        private List<ViewModel.AccountBalance> _AccountBalanceList;
        private List<int> _AccountIdList;
        private DebtCollectionAccess.Period _CurrentPeriod;
        private DebtCollectionAccess.Period _PreviousPeriod;
        private ICollection<DebtCollectionAccess.Invoice> _InvoiceList;
        private ICollection<AccountBalanceManager.Contracts.InvoiceDetail> _InvoiceDetailList;
        private ICollection<AccountBalanceManager.Contracts.PeriodDetail> _PeriodReadinessDetailList;

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

            materialTabSelector1.Width = 480;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int rowNumber = dgvPeriod.Rows.Add();
            dgvPeriod.Rows[rowNumber].Cells[1].Value = dtFromDate.Value.ToString("dd/MM/yyyy");
            dgvPeriod.Rows[rowNumber].Cells[2].Value = dtToDate.Value.ToString("dd/MM/yyyy");
            dgvPeriod.Rows[rowNumber].Cells[3].Value = dtRunDate.Value.ToString("dd/MM/yyyy");
            dgvPeriod.Rows[rowNumber].Cells[4].Value = txtBoxDescription.Text;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadPeriodList();
            assignAccountIdList();
            styleGrids();
        }
        
        private void styleGrids()
        {
            styleGrid(dgvPeriod);
            styleGrid(dgvPeriodDetail);
            styleGrid(dgvAccountBalance, 30);
            styleGrid(dgvInvoiceList);
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

        private void setLabelForCurrentPeriod()
        {
            if (_PeriodReadinessDetailList == null || !_PeriodReadinessDetailList.Any()) return;
            var periodDetail = _PeriodReadinessDetailList.FirstOrDefault(x => x.PeriodId == _CurrentPeriod.Id);
            if (periodDetail == null || !periodDetail.Readiness) return;

            btnGenerateInvoice.Enabled = true;          
            lblCurrentPeriod.Text = $"for current period {_CurrentPeriod.FromDate.ToString("dd/MM/yyyy")} - {_CurrentPeriod.ToDate.ToString("dd/MM/yyyy")}";
        }

        private void styleGrid(DataGridView dataGridView , int? ColumnHeight = null)
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

            //dgvPeriod.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9F, FontStyle.Bold);

            dataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }             

        private void loadPeriodList()
        {
            if (!periodLoadBackgroundWorker.IsBusy)
            {
                pbLoading.Visible = true;
                periodLoadBackgroundWorker.RunWorkerAsync();
            }
        }

        private void periodLoadBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var response = Periodhelper.GetPeriodList(new DebtCollectionAccess.Contracts.GetPeriodListRequest());
            _PeriodList = response.PeriodList;

            assignPeriodReadinessDetail();
        }

        private void SavePeriod_Click(object sender, EventArgs e)
        {
            var periodList = new List<DebtCollectionAccess.Period>();

            foreach (DataGridViewRow periodRow in dgvPeriod.Rows)
            {
                var period = new DebtCollectionAccess.Period
                {
                    Id = periodRow.Cells[0].Value == null ? 0 : Convert.ToInt32(periodRow.Cells[0].Value),
                    FromDate = DateTime.ParseExact(Convert.ToString(periodRow.Cells[2].Value), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None),
                    ToDate = DateTime.ParseExact(Convert.ToString(periodRow.Cells[3].Value), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None),
                    Name = Convert.ToString(periodRow.Cells[1].Value),
                    RunDate = !string.IsNullOrEmpty(Convert.ToString(periodRow.Cells[4].Value)) ? DateTime.ParseExact(periodRow.Cells[4].Value.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None) : (DateTime?)null,
                };
                periodList.Add(period);
            }

            var response = Periodhelper.PeristPeriodList(new DebtCollectionAccess.Contracts.PersistPeriodListRequest { PeriodList = periodList });        

            MessageBox.Show("Saved successfully", "Save Period", MessageBoxButtons.OK);

            btnReloadPeriod_Click(null, null);
        }     

        private void btnReloadPeriod_Click(object sender, EventArgs e)
        {
            if (!periodLoadBackgroundWorker.IsBusy)
            {
                pbLoading.Visible = true;
                pbPeriodDetailLoading.Visible = true;
                periodLoadBackgroundWorker.RunWorkerAsync();
            }
        }

        private void periodLoadBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbLoading.Visible = false;
            pbPeriodDetailLoading.Visible = false;

            if (_PeriodList == null || !_PeriodList.Any()) return;

            dgvPeriod.Rows.Clear();

            var periodList = _PeriodList;

            cmbSelectAbPeriod.DataSource = periodList;
            cmbSelectAbPeriod.DisplayMember = "Name";
            cmbSelectAbPeriod.ValueMember = "Id";

            foreach (var period in _PeriodList)
            {
                var rowNumber = dgvPeriod.Rows.Add();
                dgvPeriod.Rows[rowNumber].Cells[0].Value = period.Id;
                dgvPeriod.Rows[rowNumber].Cells[1].Value = period.Name;
                dgvPeriod.Rows[rowNumber].Cells[2].Value = period.FromDate.ToString("dd/MM/yyyy");
                dgvPeriod.Rows[rowNumber].Cells[3].Value = period.ToDate.ToString("dd/MM/yyyy");
                dgvPeriod.Rows[rowNumber].Cells[4].Value = period.RunDate.HasValue ? period.RunDate.Value.ToString("dd/MM/yyyy") : null;
                
            }

            assignCurrentPeriod();
            setLabelForCurrentPeriod();
            bindDataToPeriodDetailGrid();
            getInvoiceList();
        }

        private void bindDataToPeriodDetailGrid()
        {
            if (_PeriodReadinessDetailList == null || !_PeriodReadinessDetailList.Any()) {  return; }

            pnlLegend.Visible = true;           
            dgvPeriodDetail.Visible = true;

            var dataTable = PeriodDetailDataTableHelper.GetDataTable(_PeriodReadinessDetailList);
            dgvPeriodDetail.DataSource = dataTable;
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
                    setLabelForCurrentPeriod();
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
            });       

            if (paymentHistoryListResponse.PaymentHistoryList == null || !paymentHistoryListResponse.PaymentHistoryList.Any())
            { MessageBox.Show("No Actuals found for this date", "Payment List", MessageBoxButtons.OK); rptPaymentHistoy.Visible = false; return; }

            var paymentHistoryDataTable = PaymentHistoryDataTableHelper.GetDataTable(paymentHistoryListResponse.PaymentHistoryList,true);
            rptPaymentHistoy.Visible = true;
            rptPaymentHistoy.LocalReport.DataSources.Clear();
            var paymentHistoryDataSource = new ReportDataSource("PaymentHistory", paymentHistoryDataTable);
            rptPaymentHistoy.LocalReport.DataSources.Add(paymentHistoryDataSource);
            rptPaymentHistoy.LocalReport.Refresh();
            rptPaymentHistoy.RefreshReport();
        }

        private void getInvoiceList()
        {
            if (!bgGetInvoiceList.IsBusy)
            {
                pbLoading.Visible = true;
                bgGetInvoiceList.RunWorkerAsync();
            }
        }

        private void assignAccountIdList()
        {
            if (!accountIdListbgWorker.IsBusy)
            {
                pbLoading.Visible = true;
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

            pbLoading.Visible = false;

            var itemList = new List<string> { "--All--" };

            var accountIdListString = _AccountIdList.Select(x => Convert.ToString(x));

            itemList.AddRange(accountIdListString);

            cmbAccountId.DataSource = itemList;
        }

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            if (!bgGenerateInvoice.IsBusy)
            {
                pbLoading.Visible = true;
                lblGenerateInvoiceStatus.Text = "Generating Invoice. Please wait..";
                bgGenerateInvoice.RunWorkerAsync();
            }
        }

        private void dgvInvoiceList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;

            var selectedRow = dgvInvoiceList.Rows[e.RowIndex];
            var invoiceId = Convert.ToInt32(selectedRow.Cells[0].Value);

            var response = InvoiceHelper.GetInvoiceList(new DebtCollectionAccess.Contracts.GetInvoiceListRequest { InvoiceIdList = new List<int> { invoiceId } });

            var invoiceDetail = response.InvoiceDetailList.FirstOrDefault();          

            using (var invoicePreviewForm = new InvoicePreview())
            {
                invoicePreviewForm.InvoiceDataPreviewRequest = new InvoiceDataPreviewRequest
                {
                 InvoiceDetail = invoiceDetail,
                 InvoiceHelper = InvoiceHelper,
                };

                invoicePreviewForm.newExecute();
                invoicePreviewForm.ShowDialog();
            }

            getInvoiceList();
        }

        private void bgGenerateInvoice_DoWork(object sender, DoWorkEventArgs e)
        {
            var response = InvoiceHelper.GenerateInvoice();
        }

        private void bgGenerateInvoice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbLoading.Visible = false;
            lblGenerateInvoiceStatus.Text = string.Empty;
            MessageBox.Show("Invoice generated successfully", "Generate Invoice", MessageBoxButtons.OK);

            getInvoiceList();
        }

        private void bgGetInvoiceList_DoWork(object sender, DoWorkEventArgs e)
        {
            if (_CurrentPeriod == null) return;

            var response = InvoiceHelper.GetInvoiceList(new DebtCollectionAccess.Contracts.GetInvoiceListRequest
            {
                FromDate = _CurrentPeriod.FromDate,
                ToDate = _CurrentPeriod.ToDate,
            });           

            _InvoiceList = response.InvoiceList;
            _InvoiceDetailList = response.InvoiceDetailList;
        }

        private void bgGetInvoiceList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pbLoading.Visible = false;

            if (_InvoiceDetailList == null || !_InvoiceDetailList.Any()) return;
            List<InvoiceDataForGrid> InvoiceDataForGridList = new List<InvoiceDataForGrid>();

            foreach(var invoiceDetail in _InvoiceDetailList)
            {
                var count = invoiceDetail.InvoiceLineItemList.Count();
                var invoiceLineItem = invoiceDetail.InvoiceLineItemList.OrderByDescending(y => y.PeriodId).FirstOrDefault();
                var expenseTotal = invoiceDetail.ExpenseList?.Sum(x => x.TotalAmount) ?? 0.0M ;
                var invoiceId = invoiceDetail.InvoiceId;
                var date = invoiceDetail.GeneratedOn;
                var Yield = invoiceDetail.InvoiceLineItemList.Sum(x=> x.Yield)/ count;
                var Commission = invoiceDetail.InvoiceLineItemList.Sum(x=> x.CommissionPercentage)/ count;
                var totalOpeningBal = invoiceDetail.InvoiceLineItemList.Sum(x=>x.TotalOpeningBalance);
                var totalPaid = invoiceDetail.InvoiceLineItemList.Sum(x=>x.TotalPaid);
                var InvoiceTotal = invoiceDetail.InvoiceLineItemList.Sum(x => x.Amount) + expenseTotal ;

                var invoiceDataForGrid = new InvoiceDataForGrid
                {
                    Id = invoiceId,
                    Date = date,
                    TotalOpeningBalance = totalOpeningBal,
                    TotalPaid = totalPaid,
                    YieldPercentage = $"{Math.Round(Yield, 2, MidpointRounding.AwayFromZero)}",
                    CommisionOnYield = Commission,
                    InvoiceTotal = InvoiceTotal
                };

                InvoiceDataForGridList.Add(invoiceDataForGrid);
            }
          
            var dataTable = InvoiceDataTableHelper.GetInvoiceDataTable(InvoiceDataForGridList);

            dgvInvoiceList.Visible = true;
            dgvInvoiceList.DataSource = dataTable;

            btnGenerateInvoice.Text = "Re-Generate Invoice";
        }

        private void cmbSelectAbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            int periodId = 0;
            if (!Int32.TryParse(Convert.ToString(cmbSelectAbPeriod.SelectedValue), out periodId)) return;

            var response = AccountBalanceHelper.GetAccountBalanceList(new DebtCollectionAccess.Contracts.GetAccountBalanceListRequest
            {
                PeriodIdList = new List<int> { periodId }
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

            var response = Periodhelper.GetPeriodDetail(new AccountBalanceManager.Contracts.GetPeriodDetailListRequest());

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
                ToDate = period.ToDate
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
                    row.Cells[Constants.ACCOUNT_STATUS].Style.BackColor = Color.Red;
                    continue;
                }

                if (isPartialPayment.HasValue && isPartialPayment.Value)
                {
                    row.Cells[Constants.ACCOUNT_STATUS].Style.BackColor = Color.Yellow;
                    continue;
                }

                if (isRemainingBalanceCell == 0.0M  ||  (totalPaid >= AOD))
                {
                    row.Cells[Constants.ACCOUNT_STATUS].Style.BackColor = Color.LightGreen;
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

            foreach (DataGridViewRow row in dgvPeriodDetail.Rows)
            {
                bool readiness = Convert.ToString(row.Cells[Constants.READINESS].Value) == "Yes" ? true : false;

                row.Cells[Constants.READINESS].Style.BackColor = readiness ? Color.LightGreen : Color.Red;
            }
        }
    }
}


