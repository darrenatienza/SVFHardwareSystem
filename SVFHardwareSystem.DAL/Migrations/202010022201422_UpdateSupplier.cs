﻿namespace SVFHardwareSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSupplier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "ContactNumber", c => c.String());
            AddColumn("dbo.Suppliers", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "Address");
            DropColumn("dbo.Suppliers", "ContactNumber");
        }
    }
}