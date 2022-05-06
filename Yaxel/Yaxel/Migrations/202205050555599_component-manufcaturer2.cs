namespace Yaxel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class componentmanufcaturer2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Components", "ManufacturerId");
            AddForeignKey("dbo.Components", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Components", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Components", new[] { "ManufacturerId" });
        }
    }
}
