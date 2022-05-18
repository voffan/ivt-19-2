namespace Yaxel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropforeginkeyEmployeePeriphery : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Peripheries", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Peripheries", new[] { "EmployeeId" });
            DropColumn("dbo.Peripheries", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Peripheries", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Peripheries", "EmployeeId");
            AddForeignKey("dbo.Peripheries", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
