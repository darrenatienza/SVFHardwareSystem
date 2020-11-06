namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Address = c.String(),
                        ContactNumber = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleID = c.Int(nullable: false, identity: true),
                        CreateTimeStamp = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Cost = c.String(),
                        SIDR = c.String(),
                        IsFinished = c.Boolean(nullable: false),
                        IsFullyPaid = c.Boolean(nullable: false),
                        SaleDate = c.DateTime(nullable: false),
                        IsSaleCancel = c.Boolean(nullable: false),
                        HasReceivablePayment = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SaleID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.SalePayments",
                c => new
                    {
                        SalePaymentID = c.Int(nullable: false, identity: true),
                        SaleID = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsReceivablePayment = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SalePaymentID)
                .ForeignKey("dbo.Sales", t => t.SaleID, cascadeDelete: true)
                .Index(t => t.SaleID);
            
            CreateTable(
                "dbo.SaleProducts",
                c => new
                    {
                        SaleProductID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        SaleID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        IsToPay = c.Boolean(nullable: false),
                        IsReplace = c.Boolean(nullable: false),
                        ReplaceDate = c.DateTime(nullable: false),
                        ReplaceReason = c.String(),
                        IsCancel = c.Boolean(nullable: false),
                        CancelDate = c.DateTime(nullable: false),
                        CancelReason = c.String(),
                        IsQuantityAddedToInventoryAfterReplaceOrCancel = c.Boolean(nullable: false),
                        IsForReturnToSupplierAfterReplace = c.Boolean(nullable: false),
                        IsForReturnToSupplierAfterCancel = c.Boolean(nullable: false),
                        QuantityToReplace = c.Int(nullable: false),
                        QuantityToCancel = c.Int(nullable: false),
                        CreateTimeStamp = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SaleProductID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SaleID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.SaleID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Unit = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Limit = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductInventories",
                c => new
                    {
                        ProductInventoryID = c.Int(nullable: false, identity: true),
                        CreateTimeStamp = c.DateTime(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductInventoryID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.PurchaseProducts",
                c => new
                    {
                        PurchaseProductID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        PurchaseID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        IsQuantityUploaded = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PurchaseProductID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.PurchaseID);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        CreateTimeStamp = c.DateTime(nullable: false),
                        DatePurchase = c.DateTime(nullable: false),
                        SIDR = c.String(),
                        SupplierID = c.Int(nullable: false),
                        Remarks = c.String(),
                        IsFullyPaid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.PurchasePayments",
                c => new
                    {
                        PurchasePaymentID = c.Int(nullable: false, identity: true),
                        PurchaseID = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethodID = c.Int(nullable: false),
                        CheckNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchasePaymentID)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodID, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseID, cascadeDelete: true)
                .Index(t => t.PurchaseID)
                .Index(t => t.PaymentMethodID);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentMethodID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PaymentMethodID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNumber = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.PurchaseSaleInventories",
                c => new
                    {
                        PurchaseSaleInventoryID = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        CreateTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseSaleInventoryID);
            
            CreateTable(
                "dbo.PurchaseSaleInventoryProducts",
                c => new
                    {
                        PurchaseSaleInventoryProductID = c.Int(nullable: false, identity: true),
                        PurchaseSaleInventoryID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        BeginningQuantity = c.Int(nullable: false),
                        BeginningUnitCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseQuantity = c.Int(nullable: false),
                        PurchaseUnitCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesQuantity = c.Int(nullable: false),
                        SalesUnitCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PurchaseSaleInventoryProductID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseSaleInventories", t => t.PurchaseSaleInventoryID, cascadeDelete: true)
                .Index(t => t.PurchaseSaleInventoryID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.WarrantyProducts",
                c => new
                    {
                        WarrantyProductID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Reason = c.String(),
                        IsProductFromCancelReplace = c.Boolean(nullable: false),
                        CreateTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WarrantyProductID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarrantyProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.PurchaseSaleInventoryProducts", "PurchaseSaleInventoryID", "dbo.PurchaseSaleInventories");
            DropForeignKey("dbo.PurchaseSaleInventoryProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.SaleProducts", "SaleID", "dbo.Sales");
            DropForeignKey("dbo.SaleProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Purchases", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseProducts", "PurchaseID", "dbo.Purchases");
            DropForeignKey("dbo.PurchasePayments", "PurchaseID", "dbo.Purchases");
            DropForeignKey("dbo.PurchasePayments", "PaymentMethodID", "dbo.PaymentMethods");
            DropForeignKey("dbo.PurchaseProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductInventories", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.SalePayments", "SaleID", "dbo.Sales");
            DropForeignKey("dbo.Sales", "CustomerID", "dbo.Customers");
            DropIndex("dbo.WarrantyProducts", new[] { "ProductID" });
            DropIndex("dbo.PurchaseSaleInventoryProducts", new[] { "ProductID" });
            DropIndex("dbo.PurchaseSaleInventoryProducts", new[] { "PurchaseSaleInventoryID" });
            DropIndex("dbo.PurchasePayments", new[] { "PaymentMethodID" });
            DropIndex("dbo.PurchasePayments", new[] { "PurchaseID" });
            DropIndex("dbo.Purchases", new[] { "SupplierID" });
            DropIndex("dbo.PurchaseProducts", new[] { "PurchaseID" });
            DropIndex("dbo.PurchaseProducts", new[] { "ProductID" });
            DropIndex("dbo.ProductInventories", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.SaleProducts", new[] { "SaleID" });
            DropIndex("dbo.SaleProducts", new[] { "ProductID" });
            DropIndex("dbo.SalePayments", new[] { "SaleID" });
            DropIndex("dbo.Sales", new[] { "CustomerID" });
            DropTable("dbo.WarrantyProducts");
            DropTable("dbo.Users");
            DropTable("dbo.PurchaseSaleInventoryProducts");
            DropTable("dbo.PurchaseSaleInventories");
            DropTable("dbo.Suppliers");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.PurchasePayments");
            DropTable("dbo.Purchases");
            DropTable("dbo.PurchaseProducts");
            DropTable("dbo.ProductInventories");
            DropTable("dbo.Products");
            DropTable("dbo.SaleProducts");
            DropTable("dbo.SalePayments");
            DropTable("dbo.Sales");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
        }
    }
}
