namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsFullyPaidOnPurchase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "IsFullyPaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "IsFullyPaid");
        }
    }
}
