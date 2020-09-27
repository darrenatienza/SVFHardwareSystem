namespace SVFHardwareSystem.Ui
{
    partial class frmSalesReplaceCancel
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.btnApplyReplace = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtReplaceReason = new MetroFramework.Controls.MetroTextBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.btnApplyCancel = new MetroFramework.Controls.MetroButton();
            this.chkAddQuantity = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtCancelReason = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.lblQuantity = new MetroFramework.Controls.MetroLabel();
            this.lblProductName = new MetroFramework.Controls.MetroLabel();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(10, 141);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(491, 236);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.btnApplyReplace);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.Controls.Add(this.txtReplaceReason);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(483, 194);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Replace";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // btnApplyReplace
            // 
            this.btnApplyReplace.Location = new System.Drawing.Point(392, 168);
            this.btnApplyReplace.Name = "btnApplyReplace";
            this.btnApplyReplace.Size = new System.Drawing.Size(88, 23);
            this.btnApplyReplace.TabIndex = 4;
            this.btnApplyReplace.Text = "Apply";
            this.btnApplyReplace.UseSelectable = true;
            this.btnApplyReplace.Click += new System.EventHandler(this.btnApplyReplace_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(124, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "*Reason To Replace";
            this.metroLabel1.UseStyleColors = true;
            // 
            // txtReplaceReason
            // 
            // 
            // 
            // 
            this.txtReplaceReason.CustomButton.Image = null;
            this.txtReplaceReason.CustomButton.Location = new System.Drawing.Point(359, 1);
            this.txtReplaceReason.CustomButton.Name = "";
            this.txtReplaceReason.CustomButton.Size = new System.Drawing.Size(117, 117);
            this.txtReplaceReason.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtReplaceReason.CustomButton.TabIndex = 1;
            this.txtReplaceReason.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtReplaceReason.CustomButton.UseSelectable = true;
            this.txtReplaceReason.CustomButton.Visible = false;
            this.txtReplaceReason.Lines = new string[0];
            this.txtReplaceReason.Location = new System.Drawing.Point(3, 43);
            this.txtReplaceReason.MaxLength = 32767;
            this.txtReplaceReason.Multiline = true;
            this.txtReplaceReason.Name = "txtReplaceReason";
            this.txtReplaceReason.PasswordChar = '\0';
            this.txtReplaceReason.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtReplaceReason.SelectedText = "";
            this.txtReplaceReason.SelectionLength = 0;
            this.txtReplaceReason.SelectionStart = 0;
            this.txtReplaceReason.ShortcutsEnabled = true;
            this.txtReplaceReason.Size = new System.Drawing.Size(477, 119);
            this.txtReplaceReason.TabIndex = 2;
            this.txtReplaceReason.UseSelectable = true;
            this.txtReplaceReason.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtReplaceReason.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.btnApplyCancel);
            this.metroTabPage2.Controls.Add(this.chkAddQuantity);
            this.metroTabPage2.Controls.Add(this.metroLabel2);
            this.metroTabPage2.Controls.Add(this.txtCancelReason);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(483, 194);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Cancel";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // btnApplyCancel
            // 
            this.btnApplyCancel.Location = new System.Drawing.Point(395, 168);
            this.btnApplyCancel.Name = "btnApplyCancel";
            this.btnApplyCancel.Size = new System.Drawing.Size(88, 23);
            this.btnApplyCancel.TabIndex = 6;
            this.btnApplyCancel.Text = "Apply";
            this.btnApplyCancel.UseSelectable = true;
            this.btnApplyCancel.Click += new System.EventHandler(this.btnApplyCancel_Click);
            // 
            // chkAddQuantity
            // 
            this.chkAddQuantity.AutoSize = true;
            this.chkAddQuantity.Location = new System.Drawing.Point(324, 9);
            this.chkAddQuantity.Name = "chkAddQuantity";
            this.chkAddQuantity.Size = new System.Drawing.Size(156, 30);
            this.chkAddQuantity.TabIndex = 5;
            this.chkAddQuantity.Text = "Add Quantity to Product \r\nInventory";
            this.metroToolTip1.SetToolTip(this.chkAddQuantity, "If check, the quantity of the product that will replace / remove \r\nwill be added " +
        "to current product inventory quantity");
            this.chkAddQuantity.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 11);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(117, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "*Reason To Cancel";
            this.metroLabel2.UseStyleColors = true;
            // 
            // txtCancelReason
            // 
            // 
            // 
            // 
            this.txtCancelReason.CustomButton.Image = null;
            this.txtCancelReason.CustomButton.Location = new System.Drawing.Point(364, 1);
            this.txtCancelReason.CustomButton.Name = "";
            this.txtCancelReason.CustomButton.Size = new System.Drawing.Size(115, 115);
            this.txtCancelReason.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCancelReason.CustomButton.TabIndex = 1;
            this.txtCancelReason.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCancelReason.CustomButton.UseSelectable = true;
            this.txtCancelReason.CustomButton.Visible = false;
            this.txtCancelReason.Lines = new string[0];
            this.txtCancelReason.Location = new System.Drawing.Point(3, 45);
            this.txtCancelReason.MaxLength = 32767;
            this.txtCancelReason.Multiline = true;
            this.txtCancelReason.Name = "txtCancelReason";
            this.txtCancelReason.PasswordChar = '\0';
            this.txtCancelReason.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCancelReason.SelectedText = "";
            this.txtCancelReason.SelectionLength = 0;
            this.txtCancelReason.SelectionStart = 0;
            this.txtCancelReason.ShortcutsEnabled = true;
            this.txtCancelReason.Size = new System.Drawing.Size(480, 117);
            this.txtCancelReason.TabIndex = 4;
            this.txtCancelReason.UseSelectable = true;
            this.txtCancelReason.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCancelReason.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.metroPanel1.Controls.Add(this.lblQuantity);
            this.metroPanel1.Controls.Add(this.lblProductName);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(10, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(491, 81);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(44, 45);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(61, 19);
            this.lblQuantity.Style = MetroFramework.MetroColorStyle.Red;
            this.lblQuantity.TabIndex = 7;
            this.lblQuantity.Text = "Quantity:";
            this.lblQuantity.UseCustomBackColor = true;
            this.lblQuantity.UseStyleColors = true;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(7, 17);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(98, 19);
            this.lblProductName.Style = MetroFramework.MetroColorStyle.Red;
            this.lblProductName.TabIndex = 6;
            this.lblProductName.Text = "Product Name:";
            this.lblProductName.UseCustomBackColor = true;
            this.lblProductName.UseStyleColors = true;
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // frmSalesReplaceCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 387);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.metroPanel1);
            this.Name = "frmSalesReplaceCancel";
            this.Padding = new System.Windows.Forms.Padding(10, 60, 10, 10);
            this.Text = "Sales Replace / Cancel";
            this.Load += new System.EventHandler(this.frmSalesReturned_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtReplaceReason;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtCancelReason;
        private MetroFramework.Controls.MetroButton btnApplyReplace;
        private MetroFramework.Controls.MetroButton btnApplyCancel;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel lblProductName;
        private MetroFramework.Controls.MetroCheckBox chkAddQuantity;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroLabel lblQuantity;
    }
}