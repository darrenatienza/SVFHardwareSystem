namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPOSTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.POSPayments",
                c => new
                    {
                        POSPaymentID = c.Int(nullable: false, identity: true),
                        POSTransactionID = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.POSPaymentID)
                .ForeignKey("dbo.POSTransactions", t => t.POSTransactionID, cascadeDelete: true)
                .Index(t => t.POSTransactionID);
            
            CreateTable(
                "dbo.POSTransactions",
                c => new
                    {
                        POSTransactionID = c.Int(nullable: false, identity: true),
                        CreateTimeStamp = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        Cost = c.String(),
                        SIDR = c.String(),
                    })
                .PrimaryKey(t => t.POSTransactionID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.TransactionProducts",
                c => new
                    {
                        TransactionProductID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        POSTransactionID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        UpdateTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionProductID)
                .ForeignKey("dbo.POSTransactions", t => t.POSTransactionID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.POSTransactionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.TransactionProducts", "POSTransactionID", "dbo.POSTransactions");
            DropForeignKey("dbo.POSPayments", "POSTransactionID", "dbo.POSTransactions");
            DropForeignKey("dbo.POSTransactions", "CustomerID", "dbo.Customers");
            DropIndex("dbo.TransactionProducts", new[] { "POSTransactionID" });
            DropIndex("dbo.TransactionProducts", new[] { "ProductID" });
            DropIndex("dbo.POSTransactions", new[] { "CustomerID" });
            DropIndex("dbo.POSPayments", new[] { "POSTransactionID" });
            DropTable("dbo.TransactionProducts");
            DropTable("dbo.POSTransactions");
            DropTable("dbo.POSPayments");
        }
    }
}
