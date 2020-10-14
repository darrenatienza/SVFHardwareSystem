namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsFullyPaidOnPosTransactions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.POSTransactions", "IsFullyPaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.POSTransactions", "IsFullyPaid");
        }
    }
}
