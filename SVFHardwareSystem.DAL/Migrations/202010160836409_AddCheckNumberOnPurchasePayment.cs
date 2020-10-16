namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCheckNumberOnPurchasePayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchasePayments", "CheckNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchasePayments", "CheckNo");
        }
    }
}
