namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLimitColumnToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Limit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Limit");
        }
    }
}
