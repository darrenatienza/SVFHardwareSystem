namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsReplace_ReplaceDate_IsCancel_CancelDate_ReplaceReason_CancelReason_OnTransactionProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionProducts", "IsReplace", c => c.Boolean(nullable: false));
            AddColumn("dbo.TransactionProducts", "ReplaceDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TransactionProducts", "ReplaceReason", c => c.String());
            AddColumn("dbo.TransactionProducts", "IsCancel", c => c.Boolean(nullable: false));
            AddColumn("dbo.TransactionProducts", "CancelDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TransactionProducts", "CancelReason", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionProducts", "CancelReason");
            DropColumn("dbo.TransactionProducts", "CancelDate");
            DropColumn("dbo.TransactionProducts", "IsCancel");
            DropColumn("dbo.TransactionProducts", "ReplaceReason");
            DropColumn("dbo.TransactionProducts", "ReplaceDate");
            DropColumn("dbo.TransactionProducts", "IsReplace");
        }
    }
}
