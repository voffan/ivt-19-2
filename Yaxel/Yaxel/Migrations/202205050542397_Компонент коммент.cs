namespace Yaxel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Компоненткоммент : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Components", "ManufacturerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Components", "ManufacturerId");
        }
    }
}
