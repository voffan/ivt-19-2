namespace Yaxel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropforeginkeycomputercomponents : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Computers", "Manufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.Computers", new[] { "Manufacturer_Id" });
            DropColumn("dbo.Computers", "Manufacturer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Computers", "Manufacturer_Id", c => c.Int());
            CreateIndex("dbo.Computers", "Manufacturer_Id");
            AddForeignKey("dbo.Computers", "Manufacturer_Id", "dbo.Manufacturers", "Id");
        }
    }
}
