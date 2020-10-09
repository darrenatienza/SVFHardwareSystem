namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurchasePaymentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchasePayments",
                c => new
                    {
                        PurchasePaymentID = c.Int(nullable: false, identity: true),
                        PurchaseID = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethodID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchasePaymentID)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethodID, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseID, cascadeDelete: true)
                .Index(t => t.PurchaseID)
                .Index(t => t.PaymentMethodID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchasePayments", "PurchaseID", "dbo.Purchases");
            DropForeignKey("dbo.PurchasePayments", "PaymentMethodID", "dbo.PaymentMethods");
            DropIndex("dbo.PurchasePayments", new[] { "PaymentMethodID" });
            DropIndex("dbo.PurchasePayments", new[] { "PurchaseID" });
            DropTable("dbo.PurchasePayments");
        }
    }
}
