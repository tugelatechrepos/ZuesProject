using DebtCollection.ViewModel;

namespace DebtCollection
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PaymentHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPeriodSetUp = new System.Windows.Forms.TabPage();
            this.pbPeriodDetailLoading = new System.Windows.Forms.PictureBox();
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dgvPeriodDetail = new System.Windows.Forms.DataGridView();
            this.btnReloadPeriod = new MaterialSkin.Controls.MaterialFlatButton();
            this.tabGenerateInvoice = new System.Windows.Forms.TabPage();
            this.tabInvoices = new System.Windows.Forms.TabPage();
            this.lblGenerateInvoiceStatus = new MaterialSkin.Controls.MaterialLabel();
            this.lblCurrentPeriod = new MaterialSkin.Controls.MaterialLabel();
            this.btnGenerateInvoice = new MaterialSkin.Controls.MaterialFlatButton();
            this.dgvInvoiceList = new System.Windows.Forms.DataGridView();
            this.tabPaymentHistory = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbAccountId = new System.Windows.Forms.ComboBox();
            this.materialLabel15 = new MaterialSkin.Controls.MaterialLabel();
            this.btnGetActuals = new MaterialSkin.Controls.MaterialFlatButton();
            this.dtpActualFromDate = new System.Windows.Forms.DateTimePicker();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.dtpActualToDate = new System.Windows.Forms.DateTimePicker();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.rptPaymentHistoy = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabAccountBalance = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbSelectAbPeriod = new System.Windows.Forms.ComboBox();
            this.cmbAccountBalStatus = new System.Windows.Forms.ComboBox();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.pnlAccountBalanceStatus = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvAccountBalance = new System.Windows.Forms.DataGridView();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.periodLoadBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.periodSavebackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.accountIdListbgWorker = new System.ComponentModel.BackgroundWorker();
            this.bgGenerateInvoice = new System.ComponentModel.BackgroundWorker();
            this.bgGetInvoiceList = new System.ComponentModel.BackgroundWorker();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentHistoryBindingSource)).BeginInit();
            this.mainTabControl.SuspendLayout();
            this.tabPeriodSetUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPeriodDetailLoading)).BeginInit();
            this.pnlLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodDetail)).BeginInit();
            this.tabInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceList)).BeginInit();
            this.tabPaymentHistory.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabAccountBalance.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlAccountBalanceStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // PaymentHistoryBindingSource
            // 
            this.PaymentHistoryBindingSource.DataSource = typeof(DebtCollection.ViewModel.PaymentHistory);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPeriodSetUp);
            this.mainTabControl.Controls.Add(this.tabGenerateInvoice);
            this.mainTabControl.Controls.Add(this.tabInvoices);
            this.mainTabControl.Controls.Add(this.tabPaymentHistory);
            this.mainTabControl.Controls.Add(this.tabAccountBalance);
            this.mainTabControl.Depth = 0;
            this.mainTabControl.Location = new System.Drawing.Point(12, 161);
            this.mainTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(995, 602);
            this.mainTabControl.TabIndex = 0;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // tabPeriodSetUp
            // 
            this.tabPeriodSetUp.Controls.Add(this.pbPeriodDetailLoading);
            this.tabPeriodSetUp.Controls.Add(this.pnlLegend);
            this.tabPeriodSetUp.Controls.Add(this.dgvPeriodDetail);
            this.tabPeriodSetUp.Controls.Add(this.btnReloadPeriod);
            this.tabPeriodSetUp.Location = new System.Drawing.Point(4, 22);
            this.tabPeriodSetUp.Name = "tabPeriodSetUp";
            this.tabPeriodSetUp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPeriodSetUp.Size = new System.Drawing.Size(987, 576);
            this.tabPeriodSetUp.TabIndex = 0;
            this.tabPeriodSetUp.Text = "Periods";
            this.tabPeriodSetUp.UseVisualStyleBackColor = true;
            // 
            // pbPeriodDetailLoading
            // 
            this.pbPeriodDetailLoading.BackColor = System.Drawing.Color.Transparent;
            this.pbPeriodDetailLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbPeriodDetailLoading.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbPeriodDetailLoading.Location = new System.Drawing.Point(257, 138);
            this.pbPeriodDetailLoading.Name = "pbPeriodDetailLoading";
            this.pbPeriodDetailLoading.Size = new System.Drawing.Size(147, 100);
            this.pbPeriodDetailLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPeriodDetailLoading.TabIndex = 13;
            this.pbPeriodDetailLoading.TabStop = false;
            this.pbPeriodDetailLoading.Visible = false;
            // 
            // pnlLegend
            // 
            this.pnlLegend.Controls.Add(this.panel1);
            this.pnlLegend.Controls.Add(this.label5);
            this.pnlLegend.Controls.Add(this.label4);
            this.pnlLegend.Controls.Add(this.panel9);
            this.pnlLegend.Location = new System.Drawing.Point(560, 23);
            this.pnlLegend.Name = "pnlLegend";
            this.pnlLegend.Size = new System.Drawing.Size(282, 74);
            this.pnlLegend.TabIndex = 12;
            this.pnlLegend.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(201)))), ((int)(((byte)(55)))));
            this.panel1.Location = new System.Drawing.Point(174, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(106, 24);
            this.panel1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total Paid < Target Yield";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Total Paid >= Target Yield";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel9.Location = new System.Drawing.Point(174, 10);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(106, 24);
            this.panel9.TabIndex = 10;
            // 
            // dgvPeriodDetail
            // 
            this.dgvPeriodDetail.AllowUserToAddRows = false;
            this.dgvPeriodDetail.AllowUserToDeleteRows = false;
            this.dgvPeriodDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriodDetail.Location = new System.Drawing.Point(6, 113);
            this.dgvPeriodDetail.Name = "dgvPeriodDetail";
            this.dgvPeriodDetail.ReadOnly = true;
            this.dgvPeriodDetail.Size = new System.Drawing.Size(836, 182);
            this.dgvPeriodDetail.TabIndex = 7;
            this.dgvPeriodDetail.Visible = false;
            this.dgvPeriodDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeriodDetail_CellContentClick);
            this.dgvPeriodDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPeriodDetail_DataBindingComplete);
            // 
            // btnReloadPeriod
            // 
            this.btnReloadPeriod.AutoSize = true;
            this.btnReloadPeriod.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReloadPeriod.Depth = 0;
            this.btnReloadPeriod.Location = new System.Drawing.Point(7, 313);
            this.btnReloadPeriod.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReloadPeriod.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReloadPeriod.Name = "btnReloadPeriod";
            this.btnReloadPeriod.Primary = false;
            this.btnReloadPeriod.Size = new System.Drawing.Size(70, 36);
            this.btnReloadPeriod.TabIndex = 6;
            this.btnReloadPeriod.Text = "Refresh";
            this.btnReloadPeriod.UseVisualStyleBackColor = true;
            this.btnReloadPeriod.Click += new System.EventHandler(this.btnReloadPeriod_Click);
            // 
            // tabGenerateInvoice
            // 
            this.tabGenerateInvoice.Location = new System.Drawing.Point(4, 22);
            this.tabGenerateInvoice.Name = "tabGenerateInvoice";
            this.tabGenerateInvoice.Padding = new System.Windows.Forms.Padding(3);
            this.tabGenerateInvoice.Size = new System.Drawing.Size(987, 576);
            this.tabGenerateInvoice.TabIndex = 1;
            this.tabGenerateInvoice.Text = "Generate Invoice";
            this.tabGenerateInvoice.UseVisualStyleBackColor = true;
            // 
            // tabInvoices
            // 
            this.tabInvoices.Controls.Add(this.lblGenerateInvoiceStatus);
            this.tabInvoices.Controls.Add(this.lblCurrentPeriod);
            this.tabInvoices.Controls.Add(this.btnGenerateInvoice);
            this.tabInvoices.Controls.Add(this.dgvInvoiceList);
            this.tabInvoices.Location = new System.Drawing.Point(4, 22);
            this.tabInvoices.Name = "tabInvoices";
            this.tabInvoices.Padding = new System.Windows.Forms.Padding(3);
            this.tabInvoices.Size = new System.Drawing.Size(987, 576);
            this.tabInvoices.TabIndex = 2;
            this.tabInvoices.Text = "Invoices";
            this.tabInvoices.UseVisualStyleBackColor = true;
            // 
            // lblGenerateInvoiceStatus
            // 
            this.lblGenerateInvoiceStatus.AutoSize = true;
            this.lblGenerateInvoiceStatus.Depth = 0;
            this.lblGenerateInvoiceStatus.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblGenerateInvoiceStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblGenerateInvoiceStatus.Location = new System.Drawing.Point(24, 83);
            this.lblGenerateInvoiceStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblGenerateInvoiceStatus.Name = "lblGenerateInvoiceStatus";
            this.lblGenerateInvoiceStatus.Size = new System.Drawing.Size(0, 19);
            this.lblGenerateInvoiceStatus.TabIndex = 6;
            // 
            // lblCurrentPeriod
            // 
            this.lblCurrentPeriod.AutoSize = true;
            this.lblCurrentPeriod.Depth = 0;
            this.lblCurrentPeriod.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblCurrentPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCurrentPeriod.Location = new System.Drawing.Point(169, 32);
            this.lblCurrentPeriod.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCurrentPeriod.Name = "lblCurrentPeriod";
            this.lblCurrentPeriod.Size = new System.Drawing.Size(0, 19);
            this.lblCurrentPeriod.TabIndex = 5;
            // 
            // btnGenerateInvoice
            // 
            this.btnGenerateInvoice.AutoSize = true;
            this.btnGenerateInvoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGenerateInvoice.Depth = 0;
            this.btnGenerateInvoice.Enabled = false;
            this.btnGenerateInvoice.Location = new System.Drawing.Point(19, 24);
            this.btnGenerateInvoice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGenerateInvoice.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGenerateInvoice.Name = "btnGenerateInvoice";
            this.btnGenerateInvoice.Primary = false;
            this.btnGenerateInvoice.Size = new System.Drawing.Size(136, 36);
            this.btnGenerateInvoice.TabIndex = 4;
            this.btnGenerateInvoice.Text = "Generate Invoice";
            this.btnGenerateInvoice.UseVisualStyleBackColor = true;
            // 
            // dgvInvoiceList
            // 
            this.dgvInvoiceList.AllowUserToAddRows = false;
            this.dgvInvoiceList.AllowUserToDeleteRows = false;
            this.dgvInvoiceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceList.Location = new System.Drawing.Point(19, 143);
            this.dgvInvoiceList.Name = "dgvInvoiceList";
            this.dgvInvoiceList.ReadOnly = true;
            this.dgvInvoiceList.Size = new System.Drawing.Size(944, 384);
            this.dgvInvoiceList.TabIndex = 2;
            this.dgvInvoiceList.Visible = false;
            // 
            // tabPaymentHistory
            // 
            this.tabPaymentHistory.Controls.Add(this.groupBox2);
            this.tabPaymentHistory.Controls.Add(this.rptPaymentHistoy);
            this.tabPaymentHistory.Location = new System.Drawing.Point(4, 22);
            this.tabPaymentHistory.Name = "tabPaymentHistory";
            this.tabPaymentHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPaymentHistory.Size = new System.Drawing.Size(987, 576);
            this.tabPaymentHistory.TabIndex = 3;
            this.tabPaymentHistory.Text = "Payment History";
            this.tabPaymentHistory.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbAccountId);
            this.groupBox2.Controls.Add(this.materialLabel15);
            this.groupBox2.Controls.Add(this.btnGetActuals);
            this.groupBox2.Controls.Add(this.dtpActualFromDate);
            this.groupBox2.Controls.Add(this.materialLabel7);
            this.groupBox2.Controls.Add(this.dtpActualToDate);
            this.groupBox2.Controls.Add(this.materialLabel6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox2.Location = new System.Drawing.Point(18, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(637, 96);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // cmbAccountId
            // 
            this.cmbAccountId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountId.FormattingEnabled = true;
            this.cmbAccountId.Items.AddRange(new object[] {
            "--Select--"});
            this.cmbAccountId.Location = new System.Drawing.Point(94, 18);
            this.cmbAccountId.Name = "cmbAccountId";
            this.cmbAccountId.Size = new System.Drawing.Size(121, 24);
            this.cmbAccountId.TabIndex = 7;
            // 
            // materialLabel15
            // 
            this.materialLabel15.AutoSize = true;
            this.materialLabel15.Depth = 0;
            this.materialLabel15.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel15.Location = new System.Drawing.Point(6, 19);
            this.materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Size = new System.Drawing.Size(81, 19);
            this.materialLabel15.TabIndex = 6;
            this.materialLabel15.Text = "Account Id";
            // 
            // btnGetActuals
            // 
            this.btnGetActuals.AutoSize = true;
            this.btnGetActuals.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGetActuals.Depth = 0;
            this.btnGetActuals.Location = new System.Drawing.Point(18, 53);
            this.btnGetActuals.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGetActuals.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGetActuals.Name = "btnGetActuals";
            this.btnGetActuals.Primary = false;
            this.btnGetActuals.Size = new System.Drawing.Size(101, 36);
            this.btnGetActuals.TabIndex = 5;
            this.btnGetActuals.Text = "Get Actuals";
            this.btnGetActuals.UseVisualStyleBackColor = true;
            this.btnGetActuals.Click += new System.EventHandler(this.btnGetActuals_Click);
            // 
            // dtpActualFromDate
            // 
            this.dtpActualFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpActualFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpActualFromDate.Location = new System.Drawing.Point(322, 18);
            this.dtpActualFromDate.Name = "dtpActualFromDate";
            this.dtpActualFromDate.Size = new System.Drawing.Size(106, 23);
            this.dtpActualFromDate.TabIndex = 1;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(449, 19);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(62, 19);
            this.materialLabel7.TabIndex = 4;
            this.materialLabel7.Text = "To Date";
            // 
            // dtpActualToDate
            // 
            this.dtpActualToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpActualToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpActualToDate.Location = new System.Drawing.Point(517, 18);
            this.dtpActualToDate.Name = "dtpActualToDate";
            this.dtpActualToDate.Size = new System.Drawing.Size(106, 23);
            this.dtpActualToDate.TabIndex = 2;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(237, 18);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(79, 19);
            this.materialLabel6.TabIndex = 3;
            this.materialLabel6.Text = "From Date";
            // 
            // rptPaymentHistoy
            // 
            reportDataSource1.Name = "PaymentHistory";
            reportDataSource1.Value = this.PaymentHistoryBindingSource;
            this.rptPaymentHistoy.LocalReport.DataSources.Add(reportDataSource1);
            this.rptPaymentHistoy.LocalReport.ReportEmbeddedResource = "DebtCollection.PaymentHistoryReport.rdlc";
            this.rptPaymentHistoy.Location = new System.Drawing.Point(6, 119);
            this.rptPaymentHistoy.Name = "rptPaymentHistoy";
            this.rptPaymentHistoy.ServerReport.BearerToken = null;
            this.rptPaymentHistoy.Size = new System.Drawing.Size(962, 422);
            this.rptPaymentHistoy.TabIndex = 0;
            this.rptPaymentHistoy.Visible = false;
            // 
            // tabAccountBalance
            // 
            this.tabAccountBalance.Controls.Add(this.groupBox1);
            this.tabAccountBalance.Controls.Add(this.pnlAccountBalanceStatus);
            this.tabAccountBalance.Controls.Add(this.dgvAccountBalance);
            this.tabAccountBalance.Location = new System.Drawing.Point(4, 22);
            this.tabAccountBalance.Name = "tabAccountBalance";
            this.tabAccountBalance.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccountBalance.Size = new System.Drawing.Size(987, 576);
            this.tabAccountBalance.TabIndex = 4;
            this.tabAccountBalance.Text = "Accounts";
            this.tabAccountBalance.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAccountName);
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Controls.Add(this.cmbSelectAbPeriod);
            this.groupBox1.Controls.Add(this.cmbAccountBalStatus);
            this.groupBox1.Controls.Add(this.materialLabel13);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 127);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(123, 25);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(189, 21);
            this.txtAccountName.TabIndex = 13;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(8, 25);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(109, 19);
            this.materialLabel2.TabIndex = 12;
            this.materialLabel2.Text = "Account Name";
            // 
            // cmbSelectAbPeriod
            // 
            this.cmbSelectAbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectAbPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.cmbSelectAbPeriod.FormattingEnabled = true;
            this.cmbSelectAbPeriod.Location = new System.Drawing.Point(123, 60);
            this.cmbSelectAbPeriod.Name = "cmbSelectAbPeriod";
            this.cmbSelectAbPeriod.Size = new System.Drawing.Size(164, 21);
            this.cmbSelectAbPeriod.TabIndex = 1;
            this.cmbSelectAbPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbSelectAbPeriod_SelectedIndexChanged);
            // 
            // cmbAccountBalStatus
            // 
            this.cmbAccountBalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountBalStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.cmbAccountBalStatus.FormattingEnabled = true;
            this.cmbAccountBalStatus.Location = new System.Drawing.Point(123, 94);
            this.cmbAccountBalStatus.Name = "cmbAccountBalStatus";
            this.cmbAccountBalStatus.Size = new System.Drawing.Size(164, 21);
            this.cmbAccountBalStatus.TabIndex = 11;
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(7, 63);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(52, 19);
            this.materialLabel13.TabIndex = 2;
            this.materialLabel13.Text = "Period";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(7, 95);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(52, 19);
            this.materialLabel1.TabIndex = 10;
            this.materialLabel1.Text = "Status";
            // 
            // pnlAccountBalanceStatus
            // 
            this.pnlAccountBalanceStatus.Controls.Add(this.label3);
            this.pnlAccountBalanceStatus.Controls.Add(this.panel7);
            this.pnlAccountBalanceStatus.Controls.Add(this.label1);
            this.pnlAccountBalanceStatus.Controls.Add(this.label2);
            this.pnlAccountBalanceStatus.Controls.Add(this.panel6);
            this.pnlAccountBalanceStatus.Controls.Add(this.panel5);
            this.pnlAccountBalanceStatus.Location = new System.Drawing.Point(721, 14);
            this.pnlAccountBalanceStatus.Name = "pnlAccountBalanceStatus";
            this.pnlAccountBalanceStatus.Size = new System.Drawing.Size(258, 100);
            this.pnlAccountBalanceStatus.TabIndex = 9;
            this.pnlAccountBalanceStatus.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total Paid >=  AOD";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(201)))), ((int)(((byte)(55)))));
            this.panel7.Location = new System.Drawing.Point(119, 11);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(134, 20);
            this.panel7.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Payment Missed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Partial Payment";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(180)))), ((int)(((byte)(22)))));
            this.panel6.Location = new System.Drawing.Point(120, 67);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(132, 21);
            this.panel6.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel5.Location = new System.Drawing.Point(120, 37);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(132, 22);
            this.panel5.TabIndex = 5;
            // 
            // dgvAccountBalance
            // 
            this.dgvAccountBalance.AllowUserToAddRows = false;
            this.dgvAccountBalance.AllowUserToDeleteRows = false;
            this.dgvAccountBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountBalance.Location = new System.Drawing.Point(6, 154);
            this.dgvAccountBalance.Name = "dgvAccountBalance";
            this.dgvAccountBalance.ReadOnly = true;
            this.dgvAccountBalance.Size = new System.Drawing.Size(973, 365);
            this.dgvAccountBalance.TabIndex = 0;
            this.dgvAccountBalance.Visible = false;
            this.dgvAccountBalance.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAccountBalance_CellMouseDoubleClick);
            this.dgvAccountBalance.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAccountBalance_DataBindingComplete);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.mainTabControl;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(12, 121);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(622, 34);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // periodLoadBackgroundWorker
            // 
            this.periodLoadBackgroundWorker.WorkerReportsProgress = true;
            this.periodLoadBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.periodLoadBackgroundWorker_DoWork);
            this.periodLoadBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.periodLoadBackgroundWorker_RunWorkerCompleted);
            // 
            // accountIdListbgWorker
            // 
            this.accountIdListbgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.accountIdListbgWorker_DoWork);
            this.accountIdListbgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.accountIdListbgWorker_RunWorkerCompleted);
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(0, 0);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(16, 16);
            this.metroProgressSpinner1.TabIndex = 0;
            this.metroProgressSpinner1.UseSelectable = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 767);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.mainTabControl);
            this.Name = "MainForm";
            this.Text = "Collect.io";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PaymentHistoryBindingSource)).EndInit();
            this.mainTabControl.ResumeLayout(false);
            this.tabPeriodSetUp.ResumeLayout(false);
            this.tabPeriodSetUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPeriodDetailLoading)).EndInit();
            this.pnlLegend.ResumeLayout(false);
            this.pnlLegend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodDetail)).EndInit();
            this.tabInvoices.ResumeLayout(false);
            this.tabInvoices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceList)).EndInit();
            this.tabPaymentHistory.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabAccountBalance.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlAccountBalanceStatus.ResumeLayout(false);
            this.pnlAccountBalanceStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountBalance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPeriodSetUp;
        private System.Windows.Forms.TabPage tabGenerateInvoice;
        private System.Windows.Forms.TabPage tabInvoices;
        private System.Windows.Forms.TabPage tabPaymentHistory;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private Microsoft.Reporting.WinForms.ReportViewer rptPaymentHistoy;
        private System.Windows.Forms.BindingSource PaymentHistoryBindingSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpActualFromDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private System.Windows.Forms.DateTimePicker dtpActualToDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialFlatButton btnGetActuals;
        private System.ComponentModel.BackgroundWorker periodLoadBackgroundWorker;
        private MaterialSkin.Controls.MaterialFlatButton btnReloadPeriod;
        private System.ComponentModel.BackgroundWorker periodSavebackgroundWorker;
        private System.Windows.Forms.TabPage tabAccountBalance;
        private System.Windows.Forms.DataGridView dgvAccountBalance;
        private MaterialSkin.Controls.MaterialLabel materialLabel13;
        private System.Windows.Forms.ComboBox cmbSelectAbPeriod;
        private System.Windows.Forms.DataGridView dgvInvoiceList;
        private MaterialSkin.Controls.MaterialLabel materialLabel15;
        private System.Windows.Forms.ComboBox cmbAccountId;
        private System.ComponentModel.BackgroundWorker accountIdListbgWorker;
        private MaterialSkin.Controls.MaterialLabel lblCurrentPeriod;
        private MaterialSkin.Controls.MaterialFlatButton btnGenerateInvoice;
        private System.ComponentModel.BackgroundWorker bgGenerateInvoice;
        private System.ComponentModel.BackgroundWorker bgGetInvoiceList;
        private MaterialSkin.Controls.MaterialLabel lblGenerateInvoiceStatus;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvPeriodDetail;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlLegend;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private System.Windows.Forms.PictureBox pbPeriodDetailLoading;
        private System.Windows.Forms.Panel pnlAccountBalanceStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAccountName;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.ComboBox cmbAccountBalStatus;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}