namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurchaseSaleInventoryTables : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseSaleInventoryProducts", "PurchaseSaleInventoryID", "dbo.PurchaseSaleInventories");
            DropForeignKey("dbo.PurchaseSaleInventoryProducts", "ProductID", "dbo.Products");
            DropIndex("dbo.PurchaseSaleInventoryProducts", new[] { "ProductID" });
            DropIndex("dbo.PurchaseSaleInventoryProducts", new[] { "PurchaseSaleInventoryID" });
            DropTable("dbo.PurchaseSaleInventoryProducts");
            DropTable("dbo.PurchaseSaleInventories");
        }
    }
}
