
namespace SVFHardwareSystem.Ui
{
    partial class frmEditPointOfSaleDate
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
            this.dtNewDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.lblPrevDate = new MetroFramework.Controls.MetroLabel();
            this.lblSIDR = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.SuspendLayout();
            // 
            // dtNewDate
            // 
            this.dtNewDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNewDate.Location = new System.Drawing.Point(197, 180);
            this.dtNewDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtNewDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtNewDate.Name = "dtNewDate";
            this.dtNewDate.Size = new System.Drawing.Size(183, 29);
            this.dtNewDate.TabIndex = 0;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(197, 153);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(128, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Insert new date here";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(26, 153);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(89, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Previous Date";
            this.metroLabel2.Click += new System.EventHandler(this.metroLabel2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(293, 222);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPrevDate
            // 
            this.lblPrevDate.AutoSize = true;
            this.lblPrevDate.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPrevDate.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPrevDate.Location = new System.Drawing.Point(27, 180);
            this.lblPrevDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrevDate.Name = "lblPrevDate";
            this.lblPrevDate.Size = new System.Drawing.Size(106, 25);
            this.lblPrevDate.TabIndex = 4;
            this.lblPrevDate.Text = "01/01/2021";
            // 
            // lblSIDR
            // 
            this.lblSIDR.AutoSize = true;
            this.lblSIDR.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblSIDR.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblSIDR.Location = new System.Drawing.Point(26, 96);
            this.lblSIDR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSIDR.Name = "lblSIDR";
            this.lblSIDR.Size = new System.Drawing.Size(53, 25);
            this.lblSIDR.TabIndex = 5;
            this.lblSIDR.Text = "#000";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(27, 77);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(36, 19);
            this.metroLabel5.TabIndex = 6;
            this.metroLabel5.Text = "SIDR";
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.DarkGray;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(12, 132);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(373, 1);
            this.metroPanel1.TabIndex = 7;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // frmEditPointOfSaleDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 262);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.lblSIDR);
            this.Controls.Add(this.lblPrevDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.dtNewDate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmEditPointOfSaleDate";
            this.Padding = new System.Windows.Forms.Padding(13, 60, 13, 13);
            this.Text = "Edit Point of Sale Date";
            this.Load += new System.EventHandler(this.frmEditPointOfSaleDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroDateTime dtNewDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroLabel lblPrevDate;
        private MetroFramework.Controls.MetroLabel lblSIDR;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroPanel metroPanel1;
    }
}