﻿namespace ClothesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Address", "IsDefault", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Address", "IsDefault");
        }
    }
}
