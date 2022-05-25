namespace Yaxel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newColumnInComputer2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Computers", "ReasonRepair", c => c.String());
            AddColumn("dbo.Computers", "WritterOffTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Computers", "WritterOffTime");
            DropColumn("dbo.Computers", "ReasonRepair");
        }
    }
}
