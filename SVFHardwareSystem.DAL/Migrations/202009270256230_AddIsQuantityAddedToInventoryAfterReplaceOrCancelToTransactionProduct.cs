namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsQuantityAddedToInventoryAfterReplaceOrCancelToTransactionProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionProducts", "IsQuantityAddedToInventoryAfterReplaceOrCancel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionProducts", "IsQuantityAddedToInventoryAfterReplaceOrCancel");
        }
    }
}
