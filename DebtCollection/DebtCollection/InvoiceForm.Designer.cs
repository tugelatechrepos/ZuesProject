namespace DebtCollection
{
    partial class frmInvoice
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
            this.lblPeriodText = new MaterialSkin.Controls.MaterialLabel();
            this.dgvInvoiceList = new System.Windows.Forms.DataGridView();
            this.bgGetInvoiceList = new System.ComponentModel.BackgroundWorker();
            this.bgGenerateInvoice = new System.ComponentModel.BackgroundWorker();
            this.lblInvoiceStatus = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPeriodText
            // 
            this.lblPeriodText.AutoSize = true;
            this.lblPeriodText.Depth = 0;
            this.lblPeriodText.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblPeriodText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPeriodText.Location = new System.Drawing.Point(14, 100);
            this.lblPeriodText.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPeriodText.Name = "lblPeriodText";
            this.lblPeriodText.Size = new System.Drawing.Size(0, 19);
            this.lblPeriodText.TabIndex = 1;
            // 
            // dgvInvoiceList
            // 
            this.dgvInvoiceList.AllowUserToAddRows = false;
            this.dgvInvoiceList.AllowUserToDeleteRows = false;
            this.dgvInvoiceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceList.Location = new System.Drawing.Point(12, 216);
            this.dgvInvoiceList.Name = "dgvInvoiceList";
            this.dgvInvoiceList.ReadOnly = true;
            this.dgvInvoiceList.Size = new System.Drawing.Size(1003, 262);
            this.dgvInvoiceList.TabIndex = 2;
            this.dgvInvoiceList.Visible = false;
            // 
            // bgGetInvoiceList
            // 
            this.bgGetInvoiceList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgGetInvoiceList_DoWork);
            this.bgGetInvoiceList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgGetInvoiceList_RunWorkerCompleted);
            // 
            // bgGenerateInvoice
            // 
            this.bgGenerateInvoice.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgGenerateInvoice_DoWork);
            this.bgGenerateInvoice.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgGenerateInvoice_RunWorkerCompleted);
            // 
            // lblInvoiceStatus
            // 
            this.lblInvoiceStatus.AutoSize = true;
            this.lblInvoiceStatus.Depth = 0;
            this.lblInvoiceStatus.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblInvoiceStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblInvoiceStatus.Location = new System.Drawing.Point(18, 182);
            this.lblInvoiceStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblInvoiceStatus.Name = "lblInvoiceStatus";
            this.lblInvoiceStatus.Size = new System.Drawing.Size(108, 19);
            this.lblInvoiceStatus.TabIndex = 3;
            this.lblInvoiceStatus.Text = "materialLabel1";
            this.lblInvoiceStatus.Visible = false;
            // 
            // frmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 521);
            this.Controls.Add(this.lblInvoiceStatus);
            this.Controls.Add(this.dgvInvoiceList);
            this.Controls.Add(this.lblPeriodText);
            this.Name = "frmInvoice";
            this.Text = "Invoice";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel lblPeriodText;
        private System.Windows.Forms.DataGridView dgvInvoiceList;
        private System.ComponentModel.BackgroundWorker bgGetInvoiceList;
        private System.ComponentModel.BackgroundWorker bgGenerateInvoice;
        private MaterialSkin.Controls.MaterialLabel lblInvoiceStatus;
    }
}