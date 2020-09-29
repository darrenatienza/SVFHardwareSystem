namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateTimeStampOnTransactionProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionProducts", "CreateTimeStamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionProducts", "CreateTimeStamp");
        }
    }
}
