namespace DebtCollection
{
    partial class InvoicePreview
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
            this.dgvPaymentLineItems = new System.Windows.Forms.DataGridView();
            this.lblInvoicePreviewCurrentPeriod = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.dgvExpense = new System.Windows.Forms.DataGridView();
            this.total = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNet = new MaterialSkin.Controls.MaterialLabel();
            this.lblVat = new MaterialSkin.Controls.MaterialLabel();
            this.lblTotal = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveExpenses = new MaterialSkin.Controls.MaterialFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentLineItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPaymentLineItems
            // 
            this.dgvPaymentLineItems.AllowUserToAddRows = false;
            this.dgvPaymentLineItems.AllowUserToDeleteRows = false;
            this.dgvPaymentLineItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentLineItems.Location = new System.Drawing.Point(27, 47);
            this.dgvPaymentLineItems.Name = "dgvPaymentLineItems";
            this.dgvPaymentLineItems.ReadOnly = true;
            this.dgvPaymentLineItems.Size = new System.Drawing.Size(723, 122);
            this.dgvPaymentLineItems.TabIndex = 0;
            // 
            // lblInvoicePreviewCurrentPeriod
            // 
            this.lblInvoicePreviewCurrentPeriod.AutoSize = true;
            this.lblInvoicePreviewCurrentPeriod.Depth = 0;
            this.lblInvoicePreviewCurrentPeriod.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblInvoicePreviewCurrentPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblInvoicePreviewCurrentPeriod.Location = new System.Drawing.Point(27, 21);
            this.lblInvoicePreviewCurrentPeriod.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblInvoicePreviewCurrentPeriod.Name = "lblInvoicePreviewCurrentPeriod";
            this.lblInvoicePreviewCurrentPeriod.Size = new System.Drawing.Size(0, 19);
            this.lblInvoicePreviewCurrentPeriod.TabIndex = 1;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(27, 189);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(73, 19);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "Expenses";
            // 
            // dgvExpense
            // 
            this.dgvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpense.Location = new System.Drawing.Point(31, 222);
            this.dgvExpense.Name = "dgvExpense";
            this.dgvExpense.Size = new System.Drawing.Size(723, 141);
            this.dgvExpense.TabIndex = 3;
            this.dgvExpense.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpense_CellEndEdit);
            this.dgvExpense.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvExpense_UserDeletedRow);
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Depth = 0;
            this.total.Font = new System.Drawing.Font("Roboto", 11F);
            this.total.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.total.Location = new System.Drawing.Point(33, 22);
            this.total.MouseState = MaterialSkin.MouseState.HOVER;
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(52, 19);
            this.total.TabIndex = 4;
            this.total.Text = "Total :";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(33, 51);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(46, 19);
            this.materialLabel4.TabIndex = 5;
            this.materialLabel4.Text = "VAT :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNet);
            this.groupBox1.Controls.Add(this.lblVat);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.materialLabel5);
            this.groupBox1.Controls.Add(this.total);
            this.groupBox1.Controls.Add(this.materialLabel4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(418, 370);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 111);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Total";
            // 
            // lblNet
            // 
            this.lblNet.AutoSize = true;
            this.lblNet.Depth = 0;
            this.lblNet.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblNet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNet.Location = new System.Drawing.Point(90, 80);
            this.lblNet.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNet.Name = "lblNet";
            this.lblNet.Size = new System.Drawing.Size(46, 19);
            this.lblNet.TabIndex = 9;
            this.lblNet.Text = "NET :";
            // 
            // lblVat
            // 
            this.lblVat.AutoSize = true;
            this.lblVat.Depth = 0;
            this.lblVat.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblVat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVat.Location = new System.Drawing.Point(90, 51);
            this.lblVat.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblVat.Name = "lblVat";
            this.lblVat.Size = new System.Drawing.Size(46, 19);
            this.lblVat.TabIndex = 8;
            this.lblVat.Text = "VAT :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Depth = 0;
            this.lblTotal.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(84, 22);
            this.lblTotal.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(52, 19);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total :";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(33, 80);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(46, 19);
            this.materialLabel5.TabIndex = 6;
            this.materialLabel5.Text = "NET :";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(430, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(124, 27);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(580, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 27);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveExpenses
            // 
            this.btnSaveExpenses.AutoSize = true;
            this.btnSaveExpenses.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSaveExpenses.Depth = 0;
            this.btnSaveExpenses.Location = new System.Drawing.Point(31, 370);
            this.btnSaveExpenses.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSaveExpenses.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSaveExpenses.Name = "btnSaveExpenses";
            this.btnSaveExpenses.Primary = false;
            this.btnSaveExpenses.Size = new System.Drawing.Size(117, 36);
            this.btnSaveExpenses.TabIndex = 9;
            this.btnSaveExpenses.Text = "Save Expenses";
            this.btnSaveExpenses.UseVisualStyleBackColor = true;
            this.btnSaveExpenses.Click += new System.EventHandler(this.btnSaveExpenses_Click);
            // 
            // InvoicePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 493);
            this.Controls.Add(this.btnSaveExpenses);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvExpense);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.lblInvoicePreviewCurrentPeriod);
            this.Controls.Add(this.dgvPaymentLineItems);
            this.Name = "InvoicePreview";
            this.Text = "Invoice Preview";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentLineItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPaymentLineItems;
        private MaterialSkin.Controls.MaterialLabel lblInvoicePreviewCurrentPeriod;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DataGridView dgvExpense;
        private MaterialSkin.Controls.MaterialLabel total;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private MaterialSkin.Controls.MaterialFlatButton btnSaveExpenses;
        private MaterialSkin.Controls.MaterialLabel lblNet;
        private MaterialSkin.Controls.MaterialLabel lblVat;
        private MaterialSkin.Controls.MaterialLabel lblTotal;
    }
}