namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIFinishColumnOnPOSTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.POSTransactions", "IsFinish", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.POSTransactions", "IsFinish");
        }
    }
}
