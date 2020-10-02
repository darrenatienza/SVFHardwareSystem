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
            this.btnCategory = new MetroFramework.Controls.MetroTile();
            this.btnProduct = new MetroFramework.Controls.MetroTile();
            this.btnCustomer = new MetroFramework.Controls.MetroTile();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
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
            // btnCategory
            // 
            this.btnCategory.ActiveControl = null;
            this.btnCategory.Location = new System.Drawing.Point(414, 126);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(140, 95);
            this.btnCategory.TabIndex = 2;
            this.btnCategory.Text = "Categories";
            this.btnCategory.UseSelectable = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.ActiveControl = null;
            this.btnProduct.Location = new System.Drawing.Point(560, 126);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(140, 95);
            this.btnProduct.TabIndex = 3;
            this.btnProduct.Text = "Products";
            this.btnProduct.UseSelectable = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.ActiveControl = null;
            this.btnCustomer.Location = new System.Drawing.Point(122, 227);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(140, 95);
            this.btnCustomer.TabIndex = 4;
            this.btnCustomer.Text = "Customers";
            this.btnCustomer.UseSelectable = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(268, 227);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(140, 95);
            this.metroTile1.TabIndex = 5;
            this.metroTile1.Text = "Suppliers";
            this.metroTile1.UseSelectable = true;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnCategory);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnPointOfSale);
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnPointOfSale;
        private MetroFramework.Controls.MetroTile btnSales;
        private MetroFramework.Controls.MetroTile btnCategory;
        private MetroFramework.Controls.MetroTile btnProduct;
        private MetroFramework.Controls.MetroTile btnCustomer;
        private MetroFramework.Controls.MetroTile metroTile1;
    }
}