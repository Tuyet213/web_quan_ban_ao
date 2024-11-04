namespace ClothesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Address", "ReceiverName", c => c.String(maxLength: 100));
            AddColumn("dbo.Address", "ReceiverAddress", c => c.String());
            AddColumn("dbo.Address", "ReceiverPhone", c => c.String());
            DropColumn("dbo.Address", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Address", "Name", c => c.String(maxLength: 100));
            DropColumn("dbo.Address", "ReceiverPhone");
            DropColumn("dbo.Address", "ReceiverAddress");
            DropColumn("dbo.Address", "ReceiverName");
        }
    }
}
