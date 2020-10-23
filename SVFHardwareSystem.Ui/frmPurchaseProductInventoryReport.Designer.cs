﻿namespace SVFHardwareSystem.Ui
{
    partial class frmProductInventoryReport
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
            this.dtDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.chkTotal = new MetroFramework.Controls.MetroCheckBox();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.chkTotal);
            this.metroPanel1.Controls.Add(this.dtDate);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(760, 41);
            this.metroPanel1.TabIndex = 3;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "MMMM,yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(56, 6);
            this.dtDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(160, 29);
            this.dtDate.TabIndex = 3;
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(14, 10);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(36, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Date";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SVFHardwareSystem.Ui.Reports.PurchaseReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 101);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(760, 360);
            this.reportViewer1.TabIndex = 4;
            // 
            // chkTotal
            // 
            this.chkTotal.AutoSize = true;
            this.chkTotal.Location = new System.Drawing.Point(223, 10);
            this.chkTotal.Name = "chkTotal";
            this.chkTotal.Size = new System.Drawing.Size(123, 15);
            this.chkTotal.TabIndex = 4;
            this.chkTotal.Text = "Show Total for Year";
            this.chkTotal.UseSelectable = true;
            this.chkTotal.CheckedChanged += new System.EventHandler(this.chkTotal_CheckedChanged);
            // 
            // frmProductInventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 481);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.metroPanel1);
            this.Name = "frmProductInventoryReport";
            this.Text = "Purchase Product Inventory Report";
            this.Load += new System.EventHandler(this.frmProductMonthlyReport_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroDateTime dtDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private MetroFramework.Controls.MetroCheckBox chkTotal;
    }
}