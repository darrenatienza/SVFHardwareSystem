namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addQuantityOnProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Quantity");
        }
    }
}
