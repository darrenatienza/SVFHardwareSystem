namespace SVFHardwareSystem.Ui
{
    partial class frmPurchasePayments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtAmout = new MetroFramework.Controls.MetroTextBox();
            this.txtTotalPurchase = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.cboPaymentMethod = new MetroFramework.Controls.MetroComboBox();
            this.gridPurchasePayment = new MetroFramework.Controls.MetroGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtPaymentDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtTotalPayment = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtBalance = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPurchasePayment)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.txtBalance);
            this.metroPanel1.Controls.Add(this.metroLabel6);
            this.metroPanel1.Controls.Add(this.txtTotalPayment);
            this.metroPanel1.Controls.Add(this.metroLabel5);
            this.metroPanel1.Controls.Add(this.metroLabel4);
            this.metroPanel1.Controls.Add(this.dtPaymentDate);
            this.metroPanel1.Controls.Add(this.cboPaymentMethod);
            this.metroPanel1.Controls.Add(this.btnSave);
            this.metroPanel1.Controls.Add(this.txtTotalPurchase);
            this.metroPanel1.Controls.Add(this.txtAmout);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.metroLabel2);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(20, 60);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(247, 446);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.gridPurchasePayment);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(267, 60);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(540, 446);
            this.metroPanel2.TabIndex = 1;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(10, 249);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(109, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Payment Method";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(10, 30);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(97, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Total Purchases";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(12, 304);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(56, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Amount";
            // 
            // txtAmout
            // 
            // 
            // 
            // 
            this.txtAmout.CustomButton.Image = null;
            this.txtAmout.CustomButton.Location = new System.Drawing.Point(176, 1);
            this.txtAmout.CustomButton.Name = "";
            this.txtAmout.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtAmout.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAmout.CustomButton.TabIndex = 1;
            this.txtAmout.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAmout.CustomButton.UseSelectable = true;
            this.txtAmout.CustomButton.Visible = false;
            this.txtAmout.Lines = new string[0];
            this.txtAmout.Location = new System.Drawing.Point(10, 327);
            this.txtAmout.MaxLength = 32767;
            this.txtAmout.Name = "txtAmout";
            this.txtAmout.PasswordChar = '\0';
            this.txtAmout.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAmout.SelectedText = "";
            this.txtAmout.SelectionLength = 0;
            this.txtAmout.SelectionStart = 0;
            this.txtAmout.ShortcutsEnabled = true;
            this.txtAmout.Size = new System.Drawing.Size(198, 23);
            this.txtAmout.TabIndex = 6;
            this.txtAmout.UseSelectable = true;
            this.txtAmout.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAmout.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtTotalPurchase
            // 
            // 
            // 
            // 
            this.txtTotalPurchase.CustomButton.Image = null;
            this.txtTotalPurchase.CustomButton.Location = new System.Drawing.Point(176, 1);
            this.txtTotalPurchase.CustomButton.Name = "";
            this.txtTotalPurchase.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTotalPurchase.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalPurchase.CustomButton.TabIndex = 1;
            this.txtTotalPurchase.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalPurchase.CustomButton.UseSelectable = true;
            this.txtTotalPurchase.CustomButton.Visible = false;
            this.txtTotalPurchase.Lines = new string[0];
            this.txtTotalPurchase.Location = new System.Drawing.Point(10, 52);
            this.txtTotalPurchase.MaxLength = 32767;
            this.txtTotalPurchase.Name = "txtTotalPurchase";
            this.txtTotalPurchase.PasswordChar = '\0';
            this.txtTotalPurchase.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalPurchase.SelectedText = "";
            this.txtTotalPurchase.SelectionLength = 0;
            this.txtTotalPurchase.SelectionStart = 0;
            this.txtTotalPurchase.ShortcutsEnabled = true;
            this.txtTotalPurchase.Size = new System.Drawing.Size(198, 23);
            this.txtTotalPurchase.TabIndex = 7;
            this.txtTotalPurchase.UseSelectable = true;
            this.txtTotalPurchase.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalPurchase.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(133, 356);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.ItemHeight = 23;
            this.cboPaymentMethod.Location = new System.Drawing.Point(10, 272);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(198, 29);
            this.cboPaymentMethod.TabIndex = 9;
            this.cboPaymentMethod.UseSelectable = true;
            this.cboPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cboPaymentMethod_SelectedIndexChanged);
            // 
            // gridPurchasePayment
            // 
            this.gridPurchasePayment.AllowUserToAddRows = false;
            this.gridPurchasePayment.AllowUserToDeleteRows = false;
            this.gridPurchasePayment.AllowUserToResizeRows = false;
            this.gridPurchasePayment.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridPurchasePayment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPurchasePayment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridPurchasePayment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPurchasePayment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridPurchasePayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPurchasePayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPurchasePayment.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridPurchasePayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPurchasePayment.EnableHeadersVisualStyles = false;
            this.gridPurchasePayment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridPurchasePayment.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridPurchasePayment.Location = new System.Drawing.Point(0, 0);
            this.gridPurchasePayment.Name = "gridPurchasePayment";
            this.gridPurchasePayment.ReadOnly = true;
            this.gridPurchasePayment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPurchasePayment.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridPurchasePayment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridPurchasePayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPurchasePayment.Size = new System.Drawing.Size(540, 446);
            this.gridPurchasePayment.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "#";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Payment Date";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Payment Method";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Amount";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // dtPaymentDate
            // 
            this.dtPaymentDate.Location = new System.Drawing.Point(10, 215);
            this.dtPaymentDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtPaymentDate.Name = "dtPaymentDate";
            this.dtPaymentDate.Size = new System.Drawing.Size(200, 29);
            this.dtPaymentDate.TabIndex = 10;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(12, 193);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(90, 19);
            this.metroLabel4.TabIndex = 11;
            this.metroLabel4.Text = "Payment Date";
            // 
            // txtTotalPayment
            // 
            // 
            // 
            // 
            this.txtTotalPayment.CustomButton.Image = null;
            this.txtTotalPayment.CustomButton.Location = new System.Drawing.Point(176, 1);
            this.txtTotalPayment.CustomButton.Name = "";
            this.txtTotalPayment.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtTotalPayment.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotalPayment.CustomButton.TabIndex = 1;
            this.txtTotalPayment.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotalPayment.CustomButton.UseSelectable = true;
            this.txtTotalPayment.CustomButton.Visible = false;
            this.txtTotalPayment.Lines = new string[0];
            this.txtTotalPayment.Location = new System.Drawing.Point(10, 101);
            this.txtTotalPayment.MaxLength = 32767;
            this.txtTotalPayment.Name = "txtTotalPayment";
            this.txtTotalPayment.PasswordChar = '\0';
            this.txtTotalPayment.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotalPayment.SelectedText = "";
            this.txtTotalPayment.SelectionLength = 0;
            this.txtTotalPayment.SelectionStart = 0;
            this.txtTotalPayment.ShortcutsEnabled = true;
            this.txtTotalPayment.Size = new System.Drawing.Size(198, 23);
            this.txtTotalPayment.TabIndex = 13;
            this.txtTotalPayment.UseSelectable = true;
            this.txtTotalPayment.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotalPayment.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(10, 79);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(90, 19);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "Total Payment";
            // 
            // txtBalance
            // 
            // 
            // 
            // 
            this.txtBalance.CustomButton.Image = null;
            this.txtBalance.CustomButton.Location = new System.Drawing.Point(176, 1);
            this.txtBalance.CustomButton.Name = "";
            this.txtBalance.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBalance.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBalance.CustomButton.TabIndex = 1;
            this.txtBalance.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBalance.CustomButton.UseSelectable = true;
            this.txtBalance.CustomButton.Visible = false;
            this.txtBalance.Lines = new string[0];
            this.txtBalance.Location = new System.Drawing.Point(10, 152);
            this.txtBalance.MaxLength = 32767;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.PasswordChar = '\0';
            this.txtBalance.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBalance.SelectedText = "";
            this.txtBalance.SelectionLength = 0;
            this.txtBalance.SelectionStart = 0;
            this.txtBalance.ShortcutsEnabled = true;
            this.txtBalance.Size = new System.Drawing.Size(198, 23);
            this.txtBalance.TabIndex = 15;
            this.txtBalance.UseSelectable = true;
            this.txtBalance.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBalance.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(10, 130);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(54, 19);
            this.metroLabel6.TabIndex = 14;
            this.metroLabel6.Text = "Balance";
            // 
            // frmPurchasePayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 526);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "frmPurchasePayments";
            this.Text = "Purchase Payments";
            this.Load += new System.EventHandler(this.frmPurchasePayments_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPurchasePayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtAmout;
        private MetroFramework.Controls.MetroTextBox txtTotalPurchase;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroComboBox cboPaymentMethod;
        private MetroFramework.Controls.MetroGrid gridPurchasePayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroDateTime dtPaymentDate;
        private MetroFramework.Controls.MetroTextBox txtBalance;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtTotalPayment;
        private MetroFramework.Controls.MetroLabel metroLabel5;
    }
}