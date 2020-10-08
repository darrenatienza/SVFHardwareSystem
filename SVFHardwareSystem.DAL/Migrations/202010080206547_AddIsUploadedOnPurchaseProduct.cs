namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsUploadedOnPurchaseProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseProducts", "IsQuantityUploaded", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseProducts", "IsQuantityUploaded");
        }
    }
}
