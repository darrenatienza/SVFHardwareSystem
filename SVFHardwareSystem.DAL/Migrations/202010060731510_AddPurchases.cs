namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurchases : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        CreateTimeStamp = c.DateTime(nullable: false),
                        DatePurchase = c.DateTime(nullable: false),
                        SupplierID = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "SupplierID", "dbo.Suppliers");
            DropIndex("dbo.Purchases", new[] { "SupplierID" });
            DropTable("dbo.Purchases");
        }
    }
}
