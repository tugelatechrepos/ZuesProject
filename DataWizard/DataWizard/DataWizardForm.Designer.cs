namespace DataWizard
{
    partial class frmDataWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataWizard));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bgSetUp = new System.ComponentModel.BackgroundWorker();
            this.bgCleanUp = new System.ComponentModel.BackgroundWorker();
            this.pnlSpinner = new System.Windows.Forms.Panel();
            this.lblSpinner = new MetroFramework.Controls.MetroLabel();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.btnSetUp = new System.Windows.Forms.Button();
            this.btnCleanUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnlSpinner.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 116);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(375, 272);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCleanUp);
            this.groupBox1.Controls.Add(this.btnSetUp);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(430, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 148);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Management";
            // 
            // bgSetUp
            // 
            this.bgSetUp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSetUp_DoWork);
            this.bgSetUp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgSetUp_RunWorkerCompleted);
            // 
            // bgCleanUp
            // 
            this.bgCleanUp.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgCleanUp_DoWork);
            this.bgCleanUp.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgCleanUp_RunWorkerCompleted);
            // 
            // pnlSpinner
            // 
            this.pnlSpinner.Controls.Add(this.lblSpinner);
            this.pnlSpinner.Controls.Add(this.metroProgressSpinner1);
            this.pnlSpinner.Location = new System.Drawing.Point(179, 299);
            this.pnlSpinner.Name = "pnlSpinner";
            this.pnlSpinner.Size = new System.Drawing.Size(274, 172);
            this.pnlSpinner.TabIndex = 4;
            this.pnlSpinner.Visible = false;
            // 
            // lblSpinner
            // 
            this.lblSpinner.AutoSize = true;
            this.lblSpinner.Location = new System.Drawing.Point(87, 100);
            this.lblSpinner.Name = "lblSpinner";
            this.lblSpinner.Size = new System.Drawing.Size(83, 19);
            this.lblSpinner.TabIndex = 1;
            this.lblSpinner.Text = "metroLabel1";
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(83, 20);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(87, 77);
            this.metroProgressSpinner1.TabIndex = 0;
            this.metroProgressSpinner1.UseSelectable = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(472, 328);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(94, 19);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "metroLabel1";
            this.lblStatus.UseCustomForeColor = true;
            this.lblStatus.Visible = false;
            // 
            // btnSetUp
            // 
            this.btnSetUp.BackColor = System.Drawing.Color.LightGreen;
            this.btnSetUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetUp.Location = new System.Drawing.Point(58, 40);
            this.btnSetUp.Name = "btnSetUp";
            this.btnSetUp.Size = new System.Drawing.Size(181, 27);
            this.btnSetUp.TabIndex = 6;
            this.btnSetUp.Text = "Set Up";
            this.btnSetUp.UseVisualStyleBackColor = false;
            this.btnSetUp.Click += new System.EventHandler(this.btnSetUp_Click);
            // 
            // btnCleanUp
            // 
            this.btnCleanUp.BackColor = System.Drawing.Color.Firebrick;
            this.btnCleanUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCleanUp.Location = new System.Drawing.Point(58, 81);
            this.btnCleanUp.Name = "btnCleanUp";
            this.btnCleanUp.Size = new System.Drawing.Size(181, 31);
            this.btnCleanUp.TabIndex = 7;
            this.btnCleanUp.Text = "Clean Up";
            this.btnCleanUp.UseVisualStyleBackColor = false;
            this.btnCleanUp.Click += new System.EventHandler(this.btnCleanUp_Click);
            // 
            // frmDataWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pnlSpinner);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "frmDataWizard";
            this.Text = "Data Wizard Tool";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.pnlSpinner.ResumeLayout(false);
            this.pnlSpinner.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker bgSetUp;
        private System.ComponentModel.BackgroundWorker bgCleanUp;
        private System.Windows.Forms.Panel pnlSpinner;
        private MetroFramework.Controls.MetroLabel lblSpinner;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private System.Windows.Forms.Button btnSetUp;
        private System.Windows.Forms.Button btnCleanUp;
    }
}

