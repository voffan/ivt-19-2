namespace Yaxel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullColumnInComputer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Computers", "RepairTime", c => c.DateTime());
            AlterColumn("dbo.Computers", "WritterOffTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Computers", "WritterOffTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Computers", "RepairTime", c => c.DateTime(nullable: false));
        }
    }
}
