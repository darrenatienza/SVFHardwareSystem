namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryDealersPriceOnProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CategoryID", c => c.Int());
            AddColumn("dbo.Products", "DealersPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "CategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropColumn("dbo.Products", "DealersPrice");
            DropColumn("dbo.Products", "CategoryID");
        }
    }
}
