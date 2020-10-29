namespace SVFHardwareSystem.Ui
{
    partial class frmPointOfSalePayment
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
            this.txtTotal = new MetroFramework.Controls.MetroTextBox();
            this.lblTotal = new MetroFramework.Controls.MetroLabel();
            this.btnPay = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtAmountTendered = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtChange = new MetroFramework.Controls.MetroTextBox();
            this.lblReceivable = new MetroFramework.Controls.MetroLabel();
            this.txtReceivable = new MetroFramework.Controls.MetroTextBox();
            this.tmrControlState = new System.Windows.Forms.Timer(this.components);
            this.dtPaymentDate = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // txtTotal
            // 
            // 
            // 
            // 
            this.txtTotal.CustomButton.Image = null;
            this.txtTotal.CustomButton.Location = new System.Drawing.Point(86, 1);
            this.txtTotal.CustomButton.Name = "";
            this.txtTotal.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtTotal.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtTotal.CustomButton.TabIndex = 1;
            this.txtTotal.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtTotal.CustomButton.UseSelectable = true;
            this.txtTotal.CustomButton.Visible = false;
            this.txtTotal.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtTotal.Lines = new string[0];
            this.txtTotal.Location = new System.Drawing.Point(18, 145);
            this.txtTotal.MaxLength = 32767;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.PasswordChar = '\0';
            this.txtTotal.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTotal.SelectedText = "";
            this.txtTotal.SelectionLength = 0;
            this.txtTotal.SelectionStart = 0;
            this.txtTotal.ShortcutsEnabled = true;
            this.txtTotal.Size = new System.Drawing.Size(114, 29);
            this.txtTotal.TabIndex = 2;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.UseSelectable = true;
            this.txtTotal.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtTotal.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(18, 123);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(36, 19);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total";
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(18, 274);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(234, 38);
            this.btnPay.TabIndex = 1;
            this.btnPay.Text = "Pay";
            this.btnPay.UseSelectable = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(18, 182);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(114, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Amount Tendered";
            // 
            // txtAmountTendered
            // 
            // 
            // 
            // 
            this.txtAmountTendered.CustomButton.Image = null;
            this.txtAmountTendered.CustomButton.Location = new System.Drawing.Point(206, 1);
            this.txtAmountTendered.CustomButton.Name = "";
            this.txtAmountTendered.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtAmountTendered.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtAmountTendered.CustomButton.TabIndex = 1;
            this.txtAmountTendered.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtAmountTendered.CustomButton.UseSelectable = true;
            this.txtAmountTendered.CustomButton.Visible = false;
            this.txtAmountTendered.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtAmountTendered.Lines = new string[0];
            this.txtAmountTendered.Location = new System.Drawing.Point(18, 204);
            this.txtAmountTendered.MaxLength = 32767;
            this.txtAmountTendered.Name = "txtAmountTendered";
            this.txtAmountTendered.PasswordChar = '\0';
            this.txtAmountTendered.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAmountTendered.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAmountTendered.SelectedText = "";
            this.txtAmountTendered.SelectionLength = 0;
            this.txtAmountTendered.SelectionStart = 0;
            this.txtAmountTendered.ShortcutsEnabled = true;
            this.txtAmountTendered.Size = new System.Drawing.Size(234, 29);
            this.txtAmountTendered.TabIndex = 0;
            this.txtAmountTendered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountTendered.UseSelectable = true;
            this.txtAmountTendered.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtAmountTendered.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtAmountTendered.TextChanged += new System.EventHandler(this.txtAmountTendered_TextChanged);
            this.txtAmountTendered.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmountTendered_KeyDown);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(14, 239);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(54, 19);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Change";
            // 
            // txtChange
            // 
            // 
            // 
            // 
            this.txtChange.CustomButton.Image = null;
            this.txtChange.CustomButton.Location = new System.Drawing.Point(150, 1);
            this.txtChange.CustomButton.Name = "";
            this.txtChange.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtChange.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtChange.CustomButton.TabIndex = 1;
            this.txtChange.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtChange.CustomButton.UseSelectable = true;
            this.txtChange.CustomButton.Visible = false;
            this.txtChange.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtChange.Lines = new string[0];
            this.txtChange.Location = new System.Drawing.Point(74, 239);
            this.txtChange.MaxLength = 32767;
            this.txtChange.Name = "txtChange";
            this.txtChange.PasswordChar = '\0';
            this.txtChange.ReadOnly = true;
            this.txtChange.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtChange.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtChange.SelectedText = "";
            this.txtChange.SelectionLength = 0;
            this.txtChange.SelectionStart = 0;
            this.txtChange.ShortcutsEnabled = true;
            this.txtChange.Size = new System.Drawing.Size(178, 29);
            this.txtChange.TabIndex = 5;
            this.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChange.UseSelectable = true;
            this.txtChange.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtChange.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblReceivable
            // 
            this.lblReceivable.AutoSize = true;
            this.lblReceivable.Location = new System.Drawing.Point(138, 123);
            this.lblReceivable.Name = "lblReceivable";
            this.lblReceivable.Size = new System.Drawing.Size(71, 19);
            this.lblReceivable.TabIndex = 7;
            this.lblReceivable.Text = "Receivable";
            // 
            // txtReceivable
            // 
            // 
            // 
            // 
            this.txtReceivable.CustomButton.Image = null;
            this.txtReceivable.CustomButton.Location = new System.Drawing.Point(86, 1);
            this.txtReceivable.CustomButton.Name = "";
            this.txtReceivable.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtReceivable.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtReceivable.CustomButton.TabIndex = 1;
            this.txtReceivable.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtReceivable.CustomButton.UseSelectable = true;
            this.txtReceivable.CustomButton.Visible = false;
            this.txtReceivable.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtReceivable.Lines = new string[0];
            this.txtReceivable.Location = new System.Drawing.Point(138, 145);
            this.txtReceivable.MaxLength = 32767;
            this.txtReceivable.Name = "txtReceivable";
            this.txtReceivable.PasswordChar = '\0';
            this.txtReceivable.ReadOnly = true;
            this.txtReceivable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtReceivable.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtReceivable.SelectedText = "";
            this.txtReceivable.SelectionLength = 0;
            this.txtReceivable.SelectionStart = 0;
            this.txtReceivable.ShortcutsEnabled = true;
            this.txtReceivable.Size = new System.Drawing.Size(114, 29);
            this.txtReceivable.TabIndex = 8;
            this.txtReceivable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReceivable.UseSelectable = true;
            this.txtReceivable.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtReceivable.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tmrControlState
            // 
            this.tmrControlState.Enabled = true;
            this.tmrControlState.Tick += new System.EventHandler(this.tmrControlState_Tick);
            // 
            // dtPaymentDate
            // 
            this.dtPaymentDate.Location = new System.Drawing.Point(18, 91);
            this.dtPaymentDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtPaymentDate.Name = "dtPaymentDate";
            this.dtPaymentDate.Size = new System.Drawing.Size(234, 29);
            this.dtPaymentDate.TabIndex = 9;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(18, 69);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(90, 19);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Payment Date";
            // 
            // frmPointOfSalePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 327);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.dtPaymentDate);
            this.Controls.Add(this.lblReceivable);
            this.Controls.Add(this.txtReceivable);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtChange);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtAmountTendered);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtTotal);
            this.Name = "frmPointOfSalePayment";
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.frmPointOfSalePayment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtTotal;
        private MetroFramework.Controls.MetroLabel lblTotal;
        private MetroFramework.Controls.MetroButton btnPay;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtAmountTendered;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtChange;
        private MetroFramework.Controls.MetroLabel lblReceivable;
        private MetroFramework.Controls.MetroTextBox txtReceivable;
        private System.Windows.Forms.Timer tmrControlState;
        private MetroFramework.Controls.MetroDateTime dtPaymentDate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}