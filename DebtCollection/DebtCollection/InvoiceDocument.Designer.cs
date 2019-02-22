namespace DebtCollection
{
    partial class InvoiceDocumentForm
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
            this.rptInvoiceDocument = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptInvoiceDocument
            // 
            this.rptInvoiceDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptInvoiceDocument.LocalReport.ReportEmbeddedResource = "DebtCollection.InvoicePreview.rdlc";
            this.rptInvoiceDocument.Location = new System.Drawing.Point(0, 0);
            this.rptInvoiceDocument.Name = "rptInvoiceDocument";
            this.rptInvoiceDocument.ServerReport.BearerToken = null;
            this.rptInvoiceDocument.Size = new System.Drawing.Size(800, 450);
            this.rptInvoiceDocument.TabIndex = 0;
            // 
            // InvoiceDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptInvoiceDocument);
            this.Name = "InvoiceDocumentForm";
            this.Text = "Invoice Document";
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptInvoiceDocument;
    }
}