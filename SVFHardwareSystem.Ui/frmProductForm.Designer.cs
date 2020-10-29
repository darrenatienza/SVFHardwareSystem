namespace SVFHardwareSystem.Ui
{
    partial class frmProductForm
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtCode = new MetroFramework.Controls.MetroTextBox();
            this.txtName = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.txtLimit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtDealersPrice = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtPrice = new MetroFramework.Controls.MetroTextBox();
            this.txtUnit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cboSupplier = new MetroFramework.Controls.MetroComboBox();
            this.cboCategory = new MetroFramework.Controls.MetroComboBox();
            this.txtQuantity = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(19, 81);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(41, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Code";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(155, 81);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(95, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Product Name";
            // 
            // txtCode
            // 
            // 
            // 
            // 
            this.txtCode.CustomButton.Image = null;
            this.txtCode.CustomButton.Location = new System.Drawing.Point(108, 1);
            this.txtCode.CustomButton.Name = "";
            this.txtCode.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCode.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCode.CustomButton.TabIndex = 1;
            this.txtCode.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCode.CustomButton.UseSelectable = true;
            this.txtCode.CustomButton.Visible = false;
            this.txtCode.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtCode.Lines = new string[0];
            this.txtCode.Location = new System.Drawing.Point(23, 103);
            this.txtCode.MaxLength = 32767;
            this.txtCode.Name = "txtCode";
            this.txtCode.PasswordChar = '\0';
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCode.SelectedText = "";
            this.txtCode.SelectionLength = 0;
            this.txtCode.SelectionStart = 0;
            this.txtCode.ShortcutsEnabled = true;
            this.txtCode.Size = new System.Drawing.Size(130, 23);
            this.txtCode.TabIndex = 4;
            this.txtCode.UseSelectable = true;
            this.txtCode.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCode.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.CustomButton.Image = null;
            this.txtName.CustomButton.Location = new System.Drawing.Point(290, 2);
            this.txtName.CustomButton.Name = "";
            this.txtName.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtName.CustomButton.TabIndex = 1;
            this.txtName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtName.CustomButton.UseSelectable = true;
            this.txtName.CustomButton.Visible = false;
            this.txtName.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtName.Lines = new string[0];
            this.txtName.Location = new System.Drawing.Point(159, 103);
            this.txtName.MaxLength = 32767;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtName.SelectedText = "";
            this.txtName.SelectionLength = 0;
            this.txtName.SelectionStart = 0;
            this.txtName.ShortcutsEnabled = true;
            this.txtName.Size = new System.Drawing.Size(312, 23);
            this.txtName.TabIndex = 5;
            this.txtName.UseSelectable = true;
            this.txtName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(380, 284);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 33);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_ClickAsync);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(18, 357);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(57, 19);
            this.metroLabel7.TabIndex = 14;
            this.metroLabel7.Text = "Supplier";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(23, 177);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(64, 19);
            this.metroLabel8.TabIndex = 16;
            this.metroLabel8.Text = "Category";
            // 
            // txtLimit
            // 
            // 
            // 
            // 
            this.txtLimit.CustomButton.Image = null;
            this.txtLimit.CustomButton.Location = new System.Drawing.Point(79, 1);
            this.txtLimit.CustomButton.Name = "";
            this.txtLimit.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtLimit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtLimit.CustomButton.TabIndex = 1;
            this.txtLimit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtLimit.CustomButton.UseSelectable = true;
            this.txtLimit.CustomButton.Visible = false;
            this.txtLimit.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtLimit.Lines = new string[0];
            this.txtLimit.Location = new System.Drawing.Point(370, 255);
            this.txtLimit.MaxLength = 32767;
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.PasswordChar = '\0';
            this.txtLimit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLimit.SelectedText = "";
            this.txtLimit.SelectionLength = 0;
            this.txtLimit.SelectionStart = 0;
            this.txtLimit.ShortcutsEnabled = true;
            this.txtLimit.Size = new System.Drawing.Size(101, 23);
            this.txtLimit.TabIndex = 24;
            this.txtLimit.UseSelectable = true;
            this.txtLimit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtLimit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(370, 233);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(37, 19);
            this.metroLabel6.TabIndex = 23;
            this.metroLabel6.Text = "Limit";
            // 
            // txtDealersPrice
            // 
            // 
            // 
            // 
            this.txtDealersPrice.CustomButton.Image = null;
            this.txtDealersPrice.CustomButton.Location = new System.Drawing.Point(94, 1);
            this.txtDealersPrice.CustomButton.Name = "";
            this.txtDealersPrice.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtDealersPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDealersPrice.CustomButton.TabIndex = 1;
            this.txtDealersPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDealersPrice.CustomButton.UseSelectable = true;
            this.txtDealersPrice.CustomButton.Visible = false;
            this.txtDealersPrice.Lines = new string[0];
            this.txtDealersPrice.Location = new System.Drawing.Point(256, 386);
            this.txtDealersPrice.MaxLength = 32767;
            this.txtDealersPrice.Name = "txtDealersPrice";
            this.txtDealersPrice.PasswordChar = '\0';
            this.txtDealersPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDealersPrice.SelectedText = "";
            this.txtDealersPrice.SelectionLength = 0;
            this.txtDealersPrice.SelectionStart = 0;
            this.txtDealersPrice.ShortcutsEnabled = true;
            this.txtDealersPrice.Size = new System.Drawing.Size(116, 23);
            this.txtDealersPrice.TabIndex = 22;
            this.txtDealersPrice.UseSelectable = true;
            this.txtDealersPrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDealersPrice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(256, 364);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(87, 19);
            this.metroLabel5.TabIndex = 21;
            this.metroLabel5.Text = "Dealer\'s Price";
            // 
            // txtPrice
            // 
            // 
            // 
            // 
            this.txtPrice.CustomButton.Image = null;
            this.txtPrice.CustomButton.Location = new System.Drawing.Point(94, 1);
            this.txtPrice.CustomButton.Name = "";
            this.txtPrice.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrice.CustomButton.TabIndex = 1;
            this.txtPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrice.CustomButton.UseSelectable = true;
            this.txtPrice.CustomButton.Visible = false;
            this.txtPrice.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPrice.Lines = new string[0];
            this.txtPrice.Location = new System.Drawing.Point(248, 255);
            this.txtPrice.MaxLength = 32767;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PasswordChar = '\0';
            this.txtPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrice.SelectedText = "";
            this.txtPrice.SelectionLength = 0;
            this.txtPrice.SelectionStart = 0;
            this.txtPrice.ShortcutsEnabled = true;
            this.txtPrice.Size = new System.Drawing.Size(116, 23);
            this.txtPrice.TabIndex = 20;
            this.txtPrice.UseSelectable = true;
            this.txtPrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtUnit
            // 
            // 
            // 
            // 
            this.txtUnit.CustomButton.Image = null;
            this.txtUnit.CustomButton.Location = new System.Drawing.Point(197, 1);
            this.txtUnit.CustomButton.Name = "";
            this.txtUnit.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUnit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUnit.CustomButton.TabIndex = 1;
            this.txtUnit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUnit.CustomButton.UseSelectable = true;
            this.txtUnit.CustomButton.Visible = false;
            this.txtUnit.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtUnit.Lines = new string[0];
            this.txtUnit.Location = new System.Drawing.Point(23, 255);
            this.txtUnit.MaxLength = 32767;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.PasswordChar = '\0';
            this.txtUnit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUnit.SelectedText = "";
            this.txtUnit.SelectionLength = 0;
            this.txtUnit.SelectionStart = 0;
            this.txtUnit.ShortcutsEnabled = true;
            this.txtUnit.Size = new System.Drawing.Size(219, 23);
            this.txtUnit.TabIndex = 19;
            this.txtUnit.UseSelectable = true;
            this.txtUnit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUnit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(248, 233);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(80, 19);
            this.metroLabel4.TabIndex = 18;
            this.metroLabel4.Text = "Selling Price";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(19, 233);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(32, 19);
            this.metroLabel3.TabIndex = 17;
            this.metroLabel3.Text = "Unit";
            // 
            // cboSupplier
            // 
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.ItemHeight = 23;
            this.cboSupplier.Location = new System.Drawing.Point(23, 380);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(227, 29);
            this.cboSupplier.TabIndex = 25;
            this.cboSupplier.UseSelectable = true;
            this.cboSupplier.SelectedIndexChanged += new System.EventHandler(this.cboSupplier_SelectedIndexChanged);
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.ItemHeight = 23;
            this.cboCategory.Location = new System.Drawing.Point(23, 201);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(448, 29);
            this.cboCategory.TabIndex = 26;
            this.cboCategory.UseSelectable = true;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // txtQuantity
            // 
            // 
            // 
            // 
            this.txtQuantity.CustomButton.Image = global::SVFHardwareSystem.Ui.Properties.Resources.edit_3_48;
            this.txtQuantity.CustomButton.Location = new System.Drawing.Point(426, 1);
            this.txtQuantity.CustomButton.Name = "";
            this.txtQuantity.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtQuantity.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtQuantity.CustomButton.TabIndex = 1;
            this.txtQuantity.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtQuantity.CustomButton.UseSelectable = true;
            this.txtQuantity.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtQuantity.Lines = new string[0];
            this.txtQuantity.Location = new System.Drawing.Point(23, 151);
            this.txtQuantity.MaxLength = 32767;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PasswordChar = '\0';
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtQuantity.SelectedText = "";
            this.txtQuantity.SelectionLength = 0;
            this.txtQuantity.SelectionStart = 0;
            this.txtQuantity.ShortcutsEnabled = true;
            this.txtQuantity.ShowButton = true;
            this.txtQuantity.Size = new System.Drawing.Size(448, 23);
            this.txtQuantity.TabIndex = 28;
            this.txtQuantity.UseSelectable = true;
            this.txtQuantity.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtQuantity.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtQuantity.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.txtQuantity_ButtonClick);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(18, 129);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(58, 19);
            this.metroLabel9.TabIndex = 27;
            this.metroLabel9.Text = "Quantity";
            // 
            // frmProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 325);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.txtLimit);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtDealersPrice);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frmProductForm";
            this.Text = "Product Form";
            this.Load += new System.EventHandler(this.frmProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtCode;
        private MetroFramework.Controls.MetroTextBox txtName;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox txtLimit;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtDealersPrice;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtPrice;
        private MetroFramework.Controls.MetroTextBox txtUnit;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox cboSupplier;
        private MetroFramework.Controls.MetroComboBox cboCategory;
        private MetroFramework.Controls.MetroTextBox txtQuantity;
        private MetroFramework.Controls.MetroLabel metroLabel9;
    }
}
