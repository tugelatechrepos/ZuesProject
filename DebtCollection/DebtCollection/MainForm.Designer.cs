﻿using DebtCollection.ViewModel;

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
            this.mainTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPeriodSetUp = new System.Windows.Forms.TabPage();
            this.pbPeriodDetailLoading = new System.Windows.Forms.PictureBox();
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dgvPeriodDetail = new System.Windows.Forms.DataGridView();
            this.btnReloadPeriod = new MaterialSkin.Controls.MaterialFlatButton();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.SavePeriod = new MaterialSkin.Controls.MaterialFlatButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBoxDescription = new System.Windows.Forms.TextBox();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.btnAdd = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.dtRunDate = new System.Windows.Forms.DateTimePicker();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dgvPeriod = new System.Windows.Forms.DataGridView();
            this.txtId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFromDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtToDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRunDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.pnlAccountBalanceStatus = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.materialLabel13 = new MaterialSkin.Controls.MaterialLabel();
            this.cmbSelectAbPeriod = new System.Windows.Forms.ComboBox();
            this.dgvAccountBalance = new System.Windows.Forms.DataGridView();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.periodLoadBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.periodSavebackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.accountIdListbgWorker = new System.ComponentModel.BackgroundWorker();
            this.bgGenerateInvoice = new System.ComponentModel.BackgroundWorker();
            this.bgGetInvoiceList = new System.ComponentModel.BackgroundWorker();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.PaymentHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainTabControl.SuspendLayout();
            this.tabPeriodSetUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPeriodDetailLoading)).BeginInit();
            this.pnlLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriod)).BeginInit();
            this.tabInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceList)).BeginInit();
            this.tabPaymentHistory.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabAccountBalance.SuspendLayout();
            this.pnlAccountBalanceStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentHistoryBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.tabPeriodSetUp.Controls.Add(this.pbLoading);
            this.tabPeriodSetUp.Controls.Add(this.SavePeriod);
            this.tabPeriodSetUp.Controls.Add(this.groupBox1);
            this.tabPeriodSetUp.Controls.Add(this.dgvPeriod);
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
            this.pbPeriodDetailLoading.Image = global::DebtCollection.Properties.Resources.loader;
            this.pbPeriodDetailLoading.Location = new System.Drawing.Point(395, 362);
            this.pbPeriodDetailLoading.Name = "pbPeriodDetailLoading";
            this.pbPeriodDetailLoading.Size = new System.Drawing.Size(147, 100);
            this.pbPeriodDetailLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPeriodDetailLoading.TabIndex = 13;
            this.pbPeriodDetailLoading.TabStop = false;
            this.pbPeriodDetailLoading.Visible = false;
            // 
            // pnlLegend
            // 
            this.pnlLegend.Controls.Add(this.label5);
            this.pnlLegend.Controls.Add(this.panel8);
            this.pnlLegend.Controls.Add(this.label4);
            this.pnlLegend.Controls.Add(this.panel9);
            this.pnlLegend.Location = new System.Drawing.Point(696, 244);
            this.pnlLegend.Name = "pnlLegend";
            this.pnlLegend.Size = new System.Drawing.Size(282, 74);
            this.pnlLegend.TabIndex = 12;
            this.pnlLegend.Visible = false;
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
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.LightGreen;
            this.panel8.Location = new System.Drawing.Point(174, 43);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(106, 26);
            this.panel8.TabIndex = 11;
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
            this.panel9.BackColor = System.Drawing.Color.Red;
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
            this.dgvPeriodDetail.Location = new System.Drawing.Point(334, 322);
            this.dgvPeriodDetail.Name = "dgvPeriodDetail";
            this.dgvPeriodDetail.ReadOnly = true;
            this.dgvPeriodDetail.Size = new System.Drawing.Size(645, 239);
            this.dgvPeriodDetail.TabIndex = 7;
            this.dgvPeriodDetail.Visible = false;
            this.dgvPeriodDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPeriodDetail_DataBindingComplete);
            // 
            // btnReloadPeriod
            // 
            this.btnReloadPeriod.AutoSize = true;
            this.btnReloadPeriod.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReloadPeriod.Depth = 0;
            this.btnReloadPeriod.Location = new System.Drawing.Point(447, 244);
            this.btnReloadPeriod.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReloadPeriod.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReloadPeriod.Name = "btnReloadPeriod";
            this.btnReloadPeriod.Primary = false;
            this.btnReloadPeriod.Size = new System.Drawing.Size(114, 36);
            this.btnReloadPeriod.TabIndex = 6;
            this.btnReloadPeriod.Text = "Reload Period";
            this.btnReloadPeriod.UseVisualStyleBackColor = true;
            this.btnReloadPeriod.Click += new System.EventHandler(this.btnReloadPeriod_Click);
            // 
            // pbLoading
            // 
            this.pbLoading.BackColor = System.Drawing.Color.Transparent;
            this.pbLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbLoading.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbLoading.Image = global::DebtCollection.Properties.Resources.loader;
            this.pbLoading.Location = new System.Drawing.Point(366, 76);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(147, 100);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLoading.TabIndex = 5;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // SavePeriod
            // 
            this.SavePeriod.AutoSize = true;
            this.SavePeriod.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SavePeriod.Depth = 0;
            this.SavePeriod.Location = new System.Drawing.Point(378, 244);
            this.SavePeriod.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.SavePeriod.MouseState = MaterialSkin.MouseState.HOVER;
            this.SavePeriod.Name = "SavePeriod";
            this.SavePeriod.Primary = false;
            this.SavePeriod.Size = new System.Drawing.Size(46, 36);
            this.SavePeriod.TabIndex = 4;
            this.SavePeriod.Text = "Save";
            this.SavePeriod.UseVisualStyleBackColor = true;
            this.SavePeriod.Click += new System.EventHandler(this.SavePeriod_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBoxDescription);
            this.groupBox1.Controls.Add(this.materialLabel4);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.materialLabel3);
            this.groupBox1.Controls.Add(this.dtRunDate);
            this.groupBox1.Controls.Add(this.materialLabel2);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.materialLabel1);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 218);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Period";
            // 
            // txtBoxDescription
            // 
            this.txtBoxDescription.Location = new System.Drawing.Point(103, 131);
            this.txtBoxDescription.Name = "txtBoxDescription";
            this.txtBoxDescription.Size = new System.Drawing.Size(144, 23);
            this.txtBoxDescription.TabIndex = 9;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(6, 132);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(83, 18);
            this.materialLabel4.TabIndex = 8;
            this.materialLabel4.Text = "Description";
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.Depth = 0;
            this.btnAdd.Location = new System.Drawing.Point(10, 170);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Primary = false;
            this.btnAdd.Size = new System.Drawing.Size(94, 36);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add to grid";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(6, 91);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(70, 18);
            this.materialLabel3.TabIndex = 6;
            this.materialLabel3.Text = "Run Date";
            // 
            // dtRunDate
            // 
            this.dtRunDate.CustomFormat = "dd/MM/yyyy";
            this.dtRunDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRunDate.Location = new System.Drawing.Point(103, 89);
            this.dtRunDate.Name = "dtRunDate";
            this.dtRunDate.Size = new System.Drawing.Size(108, 23);
            this.dtRunDate.TabIndex = 5;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(6, 56);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(61, 18);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "To Date";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd/MM/yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(103, 55);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(108, 23);
            this.dtToDate.TabIndex = 3;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(6, 25);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(79, 18);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "From Date";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(103, 24);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(108, 23);
            this.dtFromDate.TabIndex = 1;
            // 
            // dgvPeriod
            // 
            this.dgvPeriod.AllowUserToAddRows = false;
            this.dgvPeriod.BackgroundColor = System.Drawing.Color.White;
            this.dgvPeriod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeriod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtId,
            this.txtName,
            this.txtFromDate,
            this.txtToDate,
            this.txtRunDate});
            this.dgvPeriod.Location = new System.Drawing.Point(334, 20);
            this.dgvPeriod.Name = "dgvPeriod";
            this.dgvPeriod.Size = new System.Drawing.Size(645, 218);
            this.dgvPeriod.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.HeaderText = "Id";
            this.txtId.Name = "txtId";
            this.txtId.Visible = false;
            this.txtId.Width = 150;
            // 
            // txtName
            // 
            this.txtName.HeaderText = "Period Name";
            this.txtName.Name = "txtName";
            this.txtName.Width = 150;
            // 
            // txtFromDate
            // 
            this.txtFromDate.HeaderText = "Start Date";
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Width = 150;
            // 
            // txtToDate
            // 
            this.txtToDate.HeaderText = "End Date";
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Width = 150;
            // 
            // txtRunDate
            // 
            this.txtRunDate.HeaderText = "Target Invoice Date";
            this.txtRunDate.Name = "txtRunDate";
            this.txtRunDate.Width = 150;
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
            this.lblGenerateInvoiceStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblGenerateInvoiceStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblGenerateInvoiceStatus.Location = new System.Drawing.Point(24, 83);
            this.lblGenerateInvoiceStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblGenerateInvoiceStatus.Name = "lblGenerateInvoiceStatus";
            this.lblGenerateInvoiceStatus.Size = new System.Drawing.Size(0, 18);
            this.lblGenerateInvoiceStatus.TabIndex = 6;
            // 
            // lblCurrentPeriod
            // 
            this.lblCurrentPeriod.AutoSize = true;
            this.lblCurrentPeriod.Depth = 0;
            this.lblCurrentPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblCurrentPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCurrentPeriod.Location = new System.Drawing.Point(169, 32);
            this.lblCurrentPeriod.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCurrentPeriod.Name = "lblCurrentPeriod";
            this.lblCurrentPeriod.Size = new System.Drawing.Size(0, 18);
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
            this.btnGenerateInvoice.Click += new System.EventHandler(this.btnGenerateInvoice_Click);
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
            this.dgvInvoiceList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvInvoiceList_CellMouseDoubleClick);
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
            this.materialLabel15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel15.Location = new System.Drawing.Point(6, 19);
            this.materialLabel15.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel15.Name = "materialLabel15";
            this.materialLabel15.Size = new System.Drawing.Size(77, 18);
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
            this.materialLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(449, 19);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(61, 18);
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
            this.materialLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(237, 18);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(79, 18);
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
            this.rptPaymentHistoy.Size = new System.Drawing.Size(959, 435);
            this.rptPaymentHistoy.TabIndex = 0;
            this.rptPaymentHistoy.Visible = false;
            // 
            // tabAccountBalance
            // 
            this.tabAccountBalance.Controls.Add(this.pnlAccountBalanceStatus);
            this.tabAccountBalance.Controls.Add(this.materialLabel13);
            this.tabAccountBalance.Controls.Add(this.cmbSelectAbPeriod);
            this.tabAccountBalance.Controls.Add(this.dgvAccountBalance);
            this.tabAccountBalance.Location = new System.Drawing.Point(4, 22);
            this.tabAccountBalance.Name = "tabAccountBalance";
            this.tabAccountBalance.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccountBalance.Size = new System.Drawing.Size(987, 576);
            this.tabAccountBalance.TabIndex = 4;
            this.tabAccountBalance.Text = "Accounts";
            this.tabAccountBalance.UseVisualStyleBackColor = true;
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
            this.panel7.BackColor = System.Drawing.Color.LightGreen;
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
            this.panel6.BackColor = System.Drawing.Color.Yellow;
            this.panel6.Location = new System.Drawing.Point(120, 67);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(132, 21);
            this.panel6.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Red;
            this.panel5.Location = new System.Drawing.Point(120, 37);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(132, 22);
            this.panel5.TabIndex = 5;
            // 
            // materialLabel13
            // 
            this.materialLabel13.AutoSize = true;
            this.materialLabel13.Depth = 0;
            this.materialLabel13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.materialLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel13.Location = new System.Drawing.Point(33, 42);
            this.materialLabel13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel13.Name = "materialLabel13";
            this.materialLabel13.Size = new System.Drawing.Size(96, 18);
            this.materialLabel13.TabIndex = 2;
            this.materialLabel13.Text = "Select Period";
            // 
            // cmbSelectAbPeriod
            // 
            this.cmbSelectAbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectAbPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSelectAbPeriod.FormattingEnabled = true;
            this.cmbSelectAbPeriod.Location = new System.Drawing.Point(135, 39);
            this.cmbSelectAbPeriod.Name = "cmbSelectAbPeriod";
            this.cmbSelectAbPeriod.Size = new System.Drawing.Size(164, 24);
            this.cmbSelectAbPeriod.TabIndex = 1;
            this.cmbSelectAbPeriod.SelectedIndexChanged += new System.EventHandler(this.cmbSelectAbPeriod_SelectedIndexChanged);
            // 
            // dgvAccountBalance
            // 
            this.dgvAccountBalance.AllowUserToAddRows = false;
            this.dgvAccountBalance.AllowUserToDeleteRows = false;
            this.dgvAccountBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountBalance.Location = new System.Drawing.Point(6, 120);
            this.dgvAccountBalance.Name = "dgvAccountBalance";
            this.dgvAccountBalance.ReadOnly = true;
            this.dgvAccountBalance.Size = new System.Drawing.Size(973, 450);
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
            // bgGenerateInvoice
            // 
            this.bgGenerateInvoice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgGenerateInvoice_DoWork);
            this.bgGenerateInvoice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgGenerateInvoice_RunWorkerCompleted);
            // 
            // bgGetInvoiceList
            // 
            this.bgGetInvoiceList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgGetInvoiceList_DoWork);
            this.bgGetInvoiceList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgGetInvoiceList_RunWorkerCompleted);
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
            // PaymentHistoryBindingSource
            // 
            this.PaymentHistoryBindingSource.DataSource = typeof(DebtCollection.ViewModel.PaymentHistory);
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
            this.mainTabControl.ResumeLayout(false);
            this.tabPeriodSetUp.ResumeLayout(false);
            this.tabPeriodSetUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPeriodDetailLoading)).EndInit();
            this.pnlLegend.ResumeLayout(false);
            this.pnlLegend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriodDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeriod)).EndInit();
            this.tabInvoices.ResumeLayout(false);
            this.tabInvoices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceList)).EndInit();
            this.tabPaymentHistory.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabAccountBalance.ResumeLayout(false);
            this.tabAccountBalance.PerformLayout();
            this.pnlAccountBalanceStatus.ResumeLayout(false);
            this.pnlAccountBalanceStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentHistoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPeriodSetUp;
        private System.Windows.Forms.TabPage tabGenerateInvoice;
        private System.Windows.Forms.TabPage tabInvoices;
        private System.Windows.Forms.TabPage tabPaymentHistory;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private System.Windows.Forms.DataGridView dgvPeriod;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialFlatButton btnAdd;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.DateTimePicker dtRunDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private MaterialSkin.Controls.MaterialFlatButton SavePeriod;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.TextBox txtBoxDescription;
        private Microsoft.Reporting.WinForms.ReportViewer rptPaymentHistoy;
        private System.Windows.Forms.BindingSource PaymentHistoryBindingSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpActualFromDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private System.Windows.Forms.DateTimePicker dtpActualToDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialFlatButton btnGetActuals;
        private System.Windows.Forms.PictureBox pbLoading;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn txtId;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtFromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtToDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRunDate;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvPeriodDetail;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlLegend;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private System.Windows.Forms.PictureBox pbPeriodDetailLoading;
        private System.Windows.Forms.Panel pnlAccountBalanceStatus;
    }
}