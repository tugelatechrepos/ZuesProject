namespace SAPGUI
{
    partial class frmPreviewPaymentHistory
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
            this.dgvPaymentHistoryPreview = new System.Windows.Forms.DataGridView();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.bgAddPaymentHistory = new System.ComponentModel.BackgroundWorker();
            this.pnlAddPaymentHistory = new System.Windows.Forms.Panel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistoryPreview)).BeginInit();
            this.pnlAddPaymentHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPaymentHistoryPreview
            // 
            this.dgvPaymentHistoryPreview.AllowUserToAddRows = false;
            this.dgvPaymentHistoryPreview.AllowUserToDeleteRows = false;
            this.dgvPaymentHistoryPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentHistoryPreview.Location = new System.Drawing.Point(23, 99);
            this.dgvPaymentHistoryPreview.Name = "dgvPaymentHistoryPreview";
            this.dgvPaymentHistoryPreview.ReadOnly = true;
            this.dgvPaymentHistoryPreview.Size = new System.Drawing.Size(719, 296);
            this.dgvPaymentHistoryPreview.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(456, 413);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(622, 413);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bgAddPaymentHistory
            // 
            this.bgAddPaymentHistory.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgAddPaymentHistory_DoWork);
            this.bgAddPaymentHistory.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgAddPaymentHistory_RunWorkerCompleted);
            // 
            // pnlAddPaymentHistory
            // 
            this.pnlAddPaymentHistory.Controls.Add(this.metroLabel2);
            this.pnlAddPaymentHistory.Controls.Add(this.metroProgressSpinner1);
            this.pnlAddPaymentHistory.Location = new System.Drawing.Point(216, 168);
            this.pnlAddPaymentHistory.Name = "pnlAddPaymentHistory";
            this.pnlAddPaymentHistory.Size = new System.Drawing.Size(286, 100);
            this.pnlAddPaymentHistory.TabIndex = 3;
            this.pnlAddPaymentHistory.Visible = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(27, 66);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(225, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Adding payment History..Please Wait";
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(53, 14);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(81, 71);
            this.metroProgressSpinner1.TabIndex = 0;
            this.metroProgressSpinner1.UseSelectable = true;
            // 
            // frmPreviewPaymentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlAddPaymentHistory);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvPaymentHistoryPreview);
            this.Name = "frmPreviewPaymentHistory";
            this.Text = "Add Payment History Preview";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistoryPreview)).EndInit();
            this.pnlAddPaymentHistory.ResumeLayout(false);
            this.pnlAddPaymentHistory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPaymentHistoryPreview;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnCancel;
        private System.ComponentModel.BackgroundWorker bgAddPaymentHistory;
        private System.Windows.Forms.Panel pnlAddPaymentHistory;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}