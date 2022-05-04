namespace Yaxel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class componentmanufacturer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Components", "ManufacturerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Components", "ManufacturerId");
            AddForeignKey("dbo.Components", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Components", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Components", new[] { "ManufacturerId" });
            DropColumn("dbo.Components", "ManufacturerId");
        }
    }
}
