namespace SAPGUI
{
    partial class AccountForm
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
            this.btnFetch = new MetroFramework.Controls.MetroButton();
            this.btnAddPaymentHistory = new MetroFramework.Controls.MetroButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnViewPaymentHistory = new MetroFramework.Controls.MetroButton();
            this.dgvAccountPaymentHistory = new System.Windows.Forms.DataGridView();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountPaymentHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(231, 80);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(75, 23);
            this.btnFetch.TabIndex = 2;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseSelectable = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // btnAddPaymentHistory
            // 
            this.btnAddPaymentHistory.Location = new System.Drawing.Point(204, 34);
            this.btnAddPaymentHistory.Name = "btnAddPaymentHistory";
            this.btnAddPaymentHistory.Size = new System.Drawing.Size(123, 23);
            this.btnAddPaymentHistory.TabIndex = 3;
            this.btnAddPaymentHistory.Text = "Add Payment History";
            this.btnAddPaymentHistory.UseSelectable = true;
            this.btnAddPaymentHistory.Click += new System.EventHandler(this.btnAddPaymentHistory_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnViewPaymentHistory);
            this.groupBox1.Controls.Add(this.btnAddPaymentHistory);
            this.groupBox1.Location = new System.Drawing.Point(429, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 76);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment History";
            // 
            // btnViewPaymentHistory
            // 
            this.btnViewPaymentHistory.Location = new System.Drawing.Point(15, 34);
            this.btnViewPaymentHistory.Name = "btnViewPaymentHistory";
            this.btnViewPaymentHistory.Size = new System.Drawing.Size(136, 23);
            this.btnViewPaymentHistory.TabIndex = 4;
            this.btnViewPaymentHistory.Text = "View Payment History";
            this.btnViewPaymentHistory.UseSelectable = true;
            this.btnViewPaymentHistory.Click += new System.EventHandler(this.btnViewPaymentHistory_Click);
            // 
            // dgvAccountPaymentHistory
            // 
            this.dgvAccountPaymentHistory.AllowUserToAddRows = false;
            this.dgvAccountPaymentHistory.AllowUserToDeleteRows = false;
            this.dgvAccountPaymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccountPaymentHistory.Location = new System.Drawing.Point(9, 137);
            this.dgvAccountPaymentHistory.Name = "dgvAccountPaymentHistory";
            this.dgvAccountPaymentHistory.ReadOnly = true;
            this.dgvAccountPaymentHistory.Size = new System.Drawing.Size(787, 360);
            this.dgvAccountPaymentHistory.TabIndex = 5;
            this.dgvAccountPaymentHistory.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(323, 80);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Account Id";
            // 
            // txtAccountId
            // 
            this.txtAccountId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountId.Location = new System.Drawing.Point(86, 81);
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(139, 21);
            this.txtAccountId.TabIndex = 9;
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.txtAccountId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvAccountPaymentHistory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFetch);
            this.Name = "AccountForm";
            this.Text = "Account Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AccountForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountPaymentHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton btnFetch;
        private MetroFramework.Controls.MetroButton btnAddPaymentHistory;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton btnViewPaymentHistory;
        private System.Windows.Forms.DataGridView dgvAccountPaymentHistory;
        private MetroFramework.Controls.MetroButton btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountId;
    }
}