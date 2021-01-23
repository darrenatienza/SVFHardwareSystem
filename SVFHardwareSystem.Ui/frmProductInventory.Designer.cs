namespace SVFHardwareSystem.Ui
{
    partial class frmProductInventory
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
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.radioPurchase = new MetroFramework.Controls.MetroRadioButton();
            this.radioBeginning = new MetroFramework.Controls.MetroRadioButton();
            this.radioEnding = new MetroFramework.Controls.MetroRadioButton();
            this.radioSale = new MetroFramework.Controls.MetroRadioButton();
            this.dtDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.spinnerLoading = new MetroFramework.Controls.MetroProgressSpinner();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.btnSave);
            this.metroPanel1.Controls.Add(this.radioPurchase);
            this.metroPanel1.Controls.Add(this.radioBeginning);
            this.metroPanel1.Controls.Add(this.radioEnding);
            this.metroPanel1.Controls.Add(this.radioSale);
            this.metroPanel1.Controls.Add(this.dtDate);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(760, 41);
            this.metroPanel1.TabIndex = 4;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(461, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radioPurchase
            // 
            this.radioPurchase.AutoSize = true;
            this.radioPurchase.Location = new System.Drawing.Point(263, 13);
            this.radioPurchase.Name = "radioPurchase";
            this.radioPurchase.Size = new System.Drawing.Size(71, 15);
            this.radioPurchase.TabIndex = 7;
            this.radioPurchase.Text = "Purchase";
            this.radioPurchase.UseSelectable = true;
            // 
            // radioBeginning
            // 
            this.radioBeginning.AutoSize = true;
            this.radioBeginning.Checked = true;
            this.radioBeginning.Location = new System.Drawing.Point(182, 13);
            this.radioBeginning.Name = "radioBeginning";
            this.radioBeginning.Size = new System.Drawing.Size(77, 15);
            this.radioBeginning.TabIndex = 6;
            this.radioBeginning.TabStop = true;
            this.radioBeginning.Text = "Beginning";
            this.radioBeginning.UseSelectable = true;
            // 
            // radioEnding
            // 
            this.radioEnding.AutoSize = true;
            this.radioEnding.Location = new System.Drawing.Point(394, 13);
            this.radioEnding.Name = "radioEnding";
            this.radioEnding.Size = new System.Drawing.Size(60, 15);
            this.radioEnding.TabIndex = 5;
            this.radioEnding.Text = "Ending";
            this.radioEnding.UseSelectable = true;
            this.radioEnding.CheckedChanged += new System.EventHandler(this.radioEnding_CheckedChanged_1);
            // 
            // radioSale
            // 
            this.radioSale.AutoSize = true;
            this.radioSale.Location = new System.Drawing.Point(344, 13);
            this.radioSale.Name = "radioSale";
            this.radioSale.Size = new System.Drawing.Size(44, 15);
            this.radioSale.TabIndex = 4;
            this.radioSale.Text = "Sale";
            this.radioSale.UseSelectable = true;
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(56, 6);
            this.dtDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(118, 29);
            this.dtDate.TabIndex = 3;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(14, 10);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(34, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Year";
            // 
            // spinnerLoading
            // 
            this.spinnerLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spinnerLoading.Location = new System.Drawing.Point(392, 244);
            this.spinnerLoading.Maximum = 100;
            this.spinnerLoading.Name = "spinnerLoading";
            this.spinnerLoading.Size = new System.Drawing.Size(24, 24);
            this.spinnerLoading.TabIndex = 8;
            this.spinnerLoading.UseSelectable = true;
            this.spinnerLoading.Value = 65;
            this.spinnerLoading.Visible = false;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SVFHardwareSystem.Ui.Reports.ProductInventory.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 101);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(760, 329);
            this.reportViewer1.TabIndex = 5;
            // 
            // frmProductInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.spinnerLoading);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.metroPanel1);
            this.Name = "frmProductInventory";
            this.Text = "Purchase and Sales";
            this.Load += new System.EventHandler(this.frmProductInventory_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroRadioButton radioSale;
        private MetroFramework.Controls.MetroDateTime dtDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private MetroFramework.Controls.MetroRadioButton radioPurchase;
        private MetroFramework.Controls.MetroRadioButton radioBeginning;
        private MetroFramework.Controls.MetroRadioButton radioEnding;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroProgressSpinner spinnerLoading;
    }
}
