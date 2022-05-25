namespace Yaxel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newColumnInComputer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Computers", "ReasonWritterOff", c => c.String());
            AddColumn("dbo.Computers", "RepairTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Computers", "RepairTime");
            DropColumn("dbo.Computers", "ReasonWritterOff");
        }
    }
}
