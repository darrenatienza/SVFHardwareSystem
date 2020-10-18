namespace SVFHardwareSystem.Ui
{
    partial class frmPayables
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.cboYear = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.chkFullyPaid = new MetroFramework.Controls.MetroCheckBox();
            this.cboSuppliers = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.cboYear);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.chkFullyPaid);
            this.metroPanel1.Controls.Add(this.cboSuppliers);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(953, 38);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.ItemHeight = 23;
            this.cboYear.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023"});
            this.cboYear.Location = new System.Drawing.Point(53, 6);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(120, 29);
            this.cboYear.TabIndex = 14;
            this.cboYear.UseSelectable = true;
            this.cboYear.SelectedIndexChanged += new System.EventHandler(this.cboYear_SelectedIndexChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(13, 10);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(34, 19);
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "Year";
            // 
            // chkFullyPaid
            // 
            this.chkFullyPaid.AutoSize = true;
            this.chkFullyPaid.Location = new System.Drawing.Point(446, 14);
            this.chkFullyPaid.Name = "chkFullyPaid";
            this.chkFullyPaid.Size = new System.Drawing.Size(106, 15);
            this.chkFullyPaid.TabIndex = 12;
            this.chkFullyPaid.Text = "Show Fully Paid";
            this.chkFullyPaid.UseSelectable = true;
            this.chkFullyPaid.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // cboSuppliers
            // 
            this.cboSuppliers.FormattingEnabled = true;
            this.cboSuppliers.ItemHeight = 23;
            this.cboSuppliers.Location = new System.Drawing.Point(242, 6);
            this.cboSuppliers.Name = "cboSuppliers";
            this.cboSuppliers.Size = new System.Drawing.Size(198, 29);
            this.cboSuppliers.TabIndex = 11;
            this.cboSuppliers.UseSelectable = true;
            this.cboSuppliers.SelectedIndexChanged += new System.EventHandler(this.cboSuppliers_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(179, 10);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(57, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Supplier";
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.reportViewer1);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(20, 98);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(953, 422);
            this.metroPanel2.TabIndex = 1;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SVFHardwareSystem.Ui.Reports.Purchases.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(953, 422);
            this.reportViewer1.TabIndex = 2;
            // 
            // frmPayables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 540);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "frmPayables";
            this.Text = "Payables";
            this.Load += new System.EventHandler(this.frmPayables_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroComboBox cboSuppliers;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroCheckBox chkFullyPaid;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private MetroFramework.Controls.MetroComboBox cboYear;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}