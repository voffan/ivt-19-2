namespace Yaxel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropColumnInComputer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Computers", "ReasonWritterOff");
            DropColumn("dbo.Computers", "WritterOffTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Computers", "WritterOffTime", c => c.DateTime());
            AddColumn("dbo.Computers", "ReasonWritterOff", c => c.String());
        }
    }
}
