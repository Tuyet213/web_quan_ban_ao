namespace ClothesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parameter", "Value", c => c.String());
            DropColumn("dbo.Parameter", "Min");
            DropColumn("dbo.Parameter", "Max");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parameter", "Max", c => c.Int(nullable: false));
            AddColumn("dbo.Parameter", "Min", c => c.Int(nullable: false));
            DropColumn("dbo.Parameter", "Value");
        }
    }
}
