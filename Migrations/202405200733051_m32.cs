namespace ClothesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m32 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rate", "Rated", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rate", "CanRate", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parameter", "Description", c => c.String());
            AddColumn("dbo.Parameter", "Unit", c => c.String());
            AddColumn("dbo.Parameter", "Apply", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Rate", "RateValue", c => c.Single());
            AlterColumn("dbo.Rate", "RatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rate", "RatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rate", "RateValue", c => c.Single(nullable: false));
            DropColumn("dbo.Parameter", "Apply");
            DropColumn("dbo.Parameter", "Unit");
            DropColumn("dbo.Parameter", "Description");
            DropColumn("dbo.Rate", "CanRate");
            DropColumn("dbo.Rate", "Rated");
        }
    }
}
