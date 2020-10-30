﻿namespace SVFHardwareSystem.Ui
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
            this.btnSupplier = new MetroFramework.Controls.MetroTile();
            this.btnPurchase = new MetroFramework.Controls.MetroTile();
            this.btnInventory = new MetroFramework.Controls.MetroTile();
            this.btnPayables = new MetroFramework.Controls.MetroTile();
            this.btnSalesMontlyReport = new MetroFramework.Controls.MetroTile();
            this.btnPurchaseProductMonthlyReport = new MetroFramework.Controls.MetroTile();
            this.btnProductSale = new MetroFramework.Controls.MetroTile();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.btnCustomerReceivables = new MetroFramework.Controls.MetroTile();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPointOfSale
            // 
            this.btnPointOfSale.ActiveControl = null;
            this.btnPointOfSale.Location = new System.Drawing.Point(4, 29);
            this.btnPointOfSale.Name = "btnPointOfSale";
            this.btnPointOfSale.Size = new System.Drawing.Size(214, 95);
            this.btnPointOfSale.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnPointOfSale.TabIndex = 0;
            this.btnPointOfSale.Text = "POINT OF SALE";
            this.btnPointOfSale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPointOfSale.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnPointOfSale.UseSelectable = true;
            this.btnPointOfSale.Click += new System.EventHandler(this.btnPointOfSale_Click);
            // 
            // btnSales
            // 
            this.btnSales.ActiveControl = null;
            this.btnSales.Location = new System.Drawing.Point(224, 29);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(140, 95);
            this.btnSales.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnSales.TabIndex = 1;
            this.btnSales.Text = "DAILY SALES";
            this.btnSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSales.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnSales.UseSelectable = true;
            this.btnSales.Click += new System.EventHandler(this.btnSales_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.ActiveControl = null;
            this.btnCategory.Location = new System.Drawing.Point(3, 18);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(401, 141);
            this.btnCategory.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCategory.TabIndex = 2;
            this.btnCategory.Text = "CATEGORIES";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCategory.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnCategory.UseSelectable = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.ActiveControl = null;
            this.btnProduct.Location = new System.Drawing.Point(213, 166);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(191, 139);
            this.btnProduct.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnProduct.TabIndex = 3;
            this.btnProduct.Text = "PRODUCTS";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProduct.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnProduct.UseSelectable = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.ActiveControl = null;
            this.btnCustomer.Location = new System.Drawing.Point(410, 18);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(320, 287);
            this.btnCustomer.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnCustomer.TabIndex = 4;
            this.btnCustomer.Text = "CUSTOMERS";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCustomer.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnCustomer.UseSelectable = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.ActiveControl = null;
            this.btnSupplier.Location = new System.Drawing.Point(3, 166);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(204, 139);
            this.btnSupplier.Style = MetroFramework.MetroColorStyle.Purple;
            this.btnSupplier.TabIndex = 5;
            this.btnSupplier.Text = "SUPPLIERS";
            this.btnSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSupplier.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnSupplier.UseSelectable = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.ActiveControl = null;
            this.btnPurchase.Location = new System.Drawing.Point(3, 17);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(225, 126);
            this.btnPurchase.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnPurchase.TabIndex = 6;
            this.btnPurchase.Text = "PURCHASES";
            this.btnPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPurchase.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnPurchase.UseSelectable = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.ActiveControl = null;
            this.btnInventory.Location = new System.Drawing.Point(3, 25);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(362, 155);
            this.btnInventory.Style = MetroFramework.MetroColorStyle.Brown;
            this.btnInventory.TabIndex = 7;
            this.btnInventory.Text = "PURCHASE AND SALES";
            this.btnInventory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnInventory.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnInventory.UseSelectable = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnPayables
            // 
            this.btnPayables.ActiveControl = null;
            this.btnPayables.Location = new System.Drawing.Point(234, 17);
            this.btnPayables.Name = "btnPayables";
            this.btnPayables.Size = new System.Drawing.Size(262, 126);
            this.btnPayables.Style = MetroFramework.MetroColorStyle.Yellow;
            this.btnPayables.TabIndex = 8;
            this.btnPayables.Text = "PAYABLES";
            this.btnPayables.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPayables.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnPayables.UseSelectable = true;
            this.btnPayables.Click += new System.EventHandler(this.btnPayables_Click);
            // 
            // btnSalesMontlyReport
            // 
            this.btnSalesMontlyReport.ActiveControl = null;
            this.btnSalesMontlyReport.Location = new System.Drawing.Point(370, 29);
            this.btnSalesMontlyReport.Name = "btnSalesMontlyReport";
            this.btnSalesMontlyReport.Size = new System.Drawing.Size(301, 95);
            this.btnSalesMontlyReport.Style = MetroFramework.MetroColorStyle.Brown;
            this.btnSalesMontlyReport.TabIndex = 9;
            this.btnSalesMontlyReport.Text = "SALE MONTHLY REPORT";
            this.btnSalesMontlyReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSalesMontlyReport.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnSalesMontlyReport.UseSelectable = true;
            this.btnSalesMontlyReport.Click += new System.EventHandler(this.btnSalesMontlyReport_Click);
            // 
            // btnPurchaseProductMonthlyReport
            // 
            this.btnPurchaseProductMonthlyReport.ActiveControl = null;
            this.btnPurchaseProductMonthlyReport.Location = new System.Drawing.Point(3, 149);
            this.btnPurchaseProductMonthlyReport.Name = "btnPurchaseProductMonthlyReport";
            this.btnPurchaseProductMonthlyReport.Size = new System.Drawing.Size(493, 134);
            this.btnPurchaseProductMonthlyReport.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnPurchaseProductMonthlyReport.TabIndex = 10;
            this.btnPurchaseProductMonthlyReport.Text = "PURCHASE PRODUCT REPORT";
            this.btnPurchaseProductMonthlyReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPurchaseProductMonthlyReport.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnPurchaseProductMonthlyReport.UseSelectable = true;
            this.btnPurchaseProductMonthlyReport.Click += new System.EventHandler(this.btnPurchaseProductMonthlyReport_Click);
            // 
            // btnProductSale
            // 
            this.btnProductSale.ActiveControl = null;
            this.btnProductSale.Location = new System.Drawing.Point(4, 130);
            this.btnProductSale.Name = "btnProductSale";
            this.btnProductSale.Size = new System.Drawing.Size(360, 149);
            this.btnProductSale.Style = MetroFramework.MetroColorStyle.Magenta;
            this.btnProductSale.TabIndex = 11;
            this.btnProductSale.Text = "SALE PRODUCT REPORT";
            this.btnProductSale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProductSale.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnProductSale.UseSelectable = true;
            this.btnProductSale.Click += new System.EventHandler(this.btnProductSale_Click);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Controls.Add(this.metroTabPage4);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(1021, 498);
            this.metroTabControl1.TabIndex = 12;
            this.metroTabControl1.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.btnCustomerReceivables);
            this.metroTabPage1.Controls.Add(this.btnSalesMontlyReport);
            this.metroTabPage1.Controls.Add(this.btnProductSale);
            this.metroTabPage1.Controls.Add(this.btnPointOfSale);
            this.metroTabPage1.Controls.Add(this.btnSales);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1013, 456);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Sales";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // btnCustomerReceivables
            // 
            this.btnCustomerReceivables.ActiveControl = null;
            this.btnCustomerReceivables.Location = new System.Drawing.Point(370, 130);
            this.btnCustomerReceivables.Name = "btnCustomerReceivables";
            this.btnCustomerReceivables.Size = new System.Drawing.Size(301, 149);
            this.btnCustomerReceivables.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnCustomerReceivables.TabIndex = 12;
            this.btnCustomerReceivables.Text = "CUSTOMERS WITH RECEIVABLES";
            this.btnCustomerReceivables.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCustomerReceivables.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnCustomerReceivables.UseSelectable = true;
            this.btnCustomerReceivables.Click += new System.EventHandler(this.btnCustomerReceivables_Click);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.btnPurchaseProductMonthlyReport);
            this.metroTabPage2.Controls.Add(this.btnPurchase);
            this.metroTabPage2.Controls.Add(this.btnPayables);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(1013, 456);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Purchase";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.btnCustomer);
            this.metroTabPage3.Controls.Add(this.btnSupplier);
            this.metroTabPage3.Controls.Add(this.btnCategory);
            this.metroTabPage3.Controls.Add(this.btnProduct);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(1013, 456);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "General";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.btnInventory);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.HorizontalScrollbarSize = 10;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(1013, 456);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "Purchase and Sale Inventory";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 578);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnPointOfSale;
        private MetroFramework.Controls.MetroTile btnSales;
        private MetroFramework.Controls.MetroTile btnCategory;
        private MetroFramework.Controls.MetroTile btnProduct;
        private MetroFramework.Controls.MetroTile btnCustomer;
        private MetroFramework.Controls.MetroTile btnSupplier;
        private MetroFramework.Controls.MetroTile btnPurchase;
        private MetroFramework.Controls.MetroTile btnInventory;
        private MetroFramework.Controls.MetroTile btnPayables;
        private MetroFramework.Controls.MetroTile btnSalesMontlyReport;
        private MetroFramework.Controls.MetroTile btnPurchaseProductMonthlyReport;
        private MetroFramework.Controls.MetroTile btnProductSale;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private MetroFramework.Controls.MetroTile btnCustomerReceivables;
    }
}