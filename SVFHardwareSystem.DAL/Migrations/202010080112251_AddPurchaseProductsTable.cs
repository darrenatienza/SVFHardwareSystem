namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurchaseProductsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseProducts",
                c => new
                    {
                        PurchaseProductID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        PurchaseID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseProductID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.PurchaseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseProducts", "PurchaseID", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseProducts", "ProductID", "dbo.Products");
            DropIndex("dbo.PurchaseProducts", new[] { "PurchaseID" });
            DropIndex("dbo.PurchaseProducts", new[] { "ProductID" });
            DropTable("dbo.PurchaseProducts");
        }
    }
}
