namespace SVFHardwareSystem.Ui
{
    partial class frmDashboard
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
            this.btnPointOfSale = new MetroFramework.Controls.MetroTile();
            this.btnSales = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // btnPointOfSale
            // 
            this.btnPointOfSale.ActiveControl = null;
            this.btnPointOfSale.Location = new System.Drawing.Point(122, 126);
            this.btnPointOfSale.Name = "btnPointOfSale";
            this.btnPointOfSale.Size = new System.Drawing.Size(140, 95);
            this.btnPointOfSale.TabIndex = 0;
            this.btnPointOfSale.Text = "Point of Sale";
            this.btnPointOfSale.UseSelectable = true;
            this.btnPointOfSale.Click += new System.EventHandler(this.btnPointOfSale_Click);
            // 
            // btnSales
            // 
            this.btnSales.ActiveControl = null;
            this.btnSales.Location = new System.Drawing.Point(268, 126);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(140, 95);
            this.btnSales.TabIndex = 1;
            this.btnSales.Text = "Sales";
            this.btnSales.UseSelectable = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnPointOfSale);
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnPointOfSale;
        private MetroFramework.Controls.MetroTile btnSales;
    }
}