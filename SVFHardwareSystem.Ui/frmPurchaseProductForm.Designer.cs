namespace SVFHardwareSystem.Ui
{
    partial class frmPurchaseProductForm
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
            this.components = new System.ComponentModel.Container();
            this.cboProduct = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtQuantity = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cboCategory = new MetroFramework.Controls.MetroComboBox();
            this.chkUploadQuantity = new MetroFramework.Controls.MetroCheckBox();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.txtUnit = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtPrice = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtTotal = new MetroFramework.Controls.MetroLabel();
            this.tmrCompute = new System.Windows.Forms.Timer(this.components);
            this.lblSelling = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // cboProduct
            // 
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.ItemHeight = 23;
            this.cboProduct.Location = new System.Drawing.Point(220, 103);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(189, 29);
            this.cboProduct.TabIndex = 0;
            this.cboProduct.UseSelectable = true;
            this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(220, 81);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(55, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Product";
            // 
            // txtQuantity
            // 
            // 
            // 
            // 
            this.txtQuantity.CustomButton.Image = null;
            this.txtQuantity.CustomButton.Location = new System.Drawing.Point(88, 1);
            this.txtQuantity.CustomButton.Name = "";
            this.txtQuantity.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtQuantity.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtQuantity.CustomButton.TabIndex = 1;
            this.txtQuantity.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtQuantity.CustomButton.UseSelectable = true;
            this.txtQuantity.CustomButton.Visible = false;
            this.txtQuantity.Lines = new string[0];
            this.txtQuantity.Location = new System.Drawing.Point(180, 165);
            this.txtQuantity.MaxLength = 32767;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PasswordChar = '\0';
            this.txtQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtQuantity.SelectedText = "";
            this.txtQuantity.SelectionLength = 0;
            this.txtQuantity.SelectionStart = 0;
            this.txtQuantity.ShortcutsEnabled = true;
            this.txtQuantity.Size = new System.Drawing.Size(110, 23);
            this.txtQuantity.TabIndex = 2;
            this.txtQuantity.UseSelectable = true;
            this.txtQuantity.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtQuantity.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(180, 143);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(58, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Quantity";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(334, 218);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(25, 81);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(64, 19);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Category";
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.ItemHeight = 23;
            this.cboCategory.Location = new System.Drawing.Point(25, 103);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(189, 29);
            this.cboCategory.TabIndex = 5;
            this.cboCategory.UseSelectable = true;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // chkUploadQuantity
            // 
            this.chkUploadQuantity.AutoSize = true;
            this.chkUploadQuantity.Location = new System.Drawing.Point(301, 63);
            this.chkUploadQuantity.Name = "chkUploadQuantity";
            this.chkUploadQuantity.Size = new System.Drawing.Size(110, 15);
            this.chkUploadQuantity.TabIndex = 7;
            this.chkUploadQuantity.Text = "Upload Quantity";
            this.metroToolTip1.SetToolTip(this.chkUploadQuantity, "Quantity will automatically reflect to the current inventory count of the product" +
        "");
            this.chkUploadQuantity.UseSelectable = true;
            this.chkUploadQuantity.Visible = false;
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // txtUnit
            // 
            // 
            // 
            // 
            this.txtUnit.CustomButton.Image = null;
            this.txtUnit.CustomButton.Location = new System.Drawing.Point(127, 1);
            this.txtUnit.CustomButton.Name = "";
            this.txtUnit.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUnit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUnit.CustomButton.TabIndex = 1;
            this.txtUnit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUnit.CustomButton.UseSelectable = true;
            this.txtUnit.CustomButton.Visible = false;
            this.txtUnit.Lines = new string[0];
            this.txtUnit.Location = new System.Drawing.Point(25, 165);
            this.txtUnit.MaxLength = 32767;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.PasswordChar = '\0';
            this.txtUnit.ReadOnly = true;
            this.txtUnit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUnit.SelectedText = "";
            this.txtUnit.SelectionLength = 0;
            this.txtUnit.SelectionStart = 0;
            this.txtUnit.ShortcutsEnabled = true;
            this.txtUnit.Size = new System.Drawing.Size(149, 23);
            this.txtUnit.TabIndex = 11;
            this.metroToolTip1.SetToolTip(this.txtUnit, "Unit base on product selling not on purchase.");
            this.txtUnit.UseSelectable = true;
            this.txtUnit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUnit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(296, 143);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(65, 19);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "Unit Price";
            // 
            // txtPrice
            // 
            // 
            // 
            // 
            this.txtPrice.CustomButton.Image = null;
            this.txtPrice.CustomButton.Location = new System.Drawing.Point(93, 1);
            this.txtPrice.CustomButton.Name = "";
            this.txtPrice.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPrice.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPrice.CustomButton.TabIndex = 1;
            this.txtPrice.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPrice.CustomButton.UseSelectable = true;
            this.txtPrice.CustomButton.Visible = false;
            this.txtPrice.Lines = new string[0];
            this.txtPrice.Location = new System.Drawing.Point(296, 165);
            this.txtPrice.MaxLength = 32767;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PasswordChar = '\0';
            this.txtPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPrice.SelectedText = "";
            this.txtPrice.SelectionLength = 0;
            this.txtPrice.SelectionStart = 0;
            this.txtPrice.ShortcutsEnabled = true;
            this.txtPrice.Size = new System.Drawing.Size(115, 23);
            this.txtPrice.TabIndex = 8;
            this.metroToolTip1.SetToolTip(this.txtPrice, "Your purchase unit price from supplier");
            this.txtPrice.UseSelectable = true;
            this.txtPrice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPrice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(25, 143);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(32, 19);
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "Unit";
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.txtTotal.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.txtTotal.Location = new System.Drawing.Point(23, 191);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(89, 25);
            this.txtTotal.TabIndex = 12;
            this.txtTotal.Text = "Total: 0.0";
            // 
            // tmrCompute
            // 
            this.tmrCompute.Enabled = true;
            this.tmrCompute.Tick += new System.EventHandler(this.tmrCompute_Tick);
            // 
            // lblSelling
            // 
            this.lblSelling.AutoSize = true;
            this.lblSelling.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblSelling.Location = new System.Drawing.Point(270, 191);
            this.lblSelling.Name = "lblSelling";
            this.lblSelling.Size = new System.Drawing.Size(91, 15);
            this.lblSelling.Style = MetroFramework.MetroColorStyle.Red;
            this.lblSelling.TabIndex = 13;
            this.lblSelling.Text = "Selling Unit Price:";
            this.metroToolTip1.SetToolTip(this.lblSelling, "Selling of product to your customer");
            this.lblSelling.UseStyleColors = true;
            // 
            // frmPurchaseProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 254);
            this.Controls.Add(this.lblSelling);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.chkUploadQuantity);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cboProduct);
            this.Name = "frmPurchaseProductForm";
            this.Text = "Purchase Product";
            this.Load += new System.EventHandler(this.frmPurchaseProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cboProduct;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtQuantity;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox cboCategory;
        private MetroFramework.Controls.MetroCheckBox chkUploadQuantity;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtPrice;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox txtUnit;
        private MetroFramework.Controls.MetroLabel txtTotal;
        private System.Windows.Forms.Timer tmrCompute;
        private MetroFramework.Controls.MetroLabel lblSelling;
    }
}