namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSupplierAndSupplierProductToReturn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplierProductToReturns",
                c => new
                    {
                        SupplierProductToReturnID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Reason = c.String(),
                        IsProductFromCancelReplace = c.Boolean(nullable: false),
                        CreateTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierProductToReturnID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplierProductToReturns", "ProductID", "dbo.Products");
            DropIndex("dbo.SupplierProductToReturns", new[] { "ProductID" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.SupplierProductToReturns");
        }
    }
}
