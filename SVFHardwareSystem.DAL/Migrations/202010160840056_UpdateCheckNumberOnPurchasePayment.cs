namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCheckNumberOnPurchasePayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchasePayments", "CheckNumber", c => c.Int(nullable: false));
            DropColumn("dbo.PurchasePayments", "CheckNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchasePayments", "CheckNo", c => c.String());
            DropColumn("dbo.PurchasePayments", "CheckNumber");
        }
    }
}
