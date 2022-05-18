namespace Yaxel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyComputerPeriphery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PeripheryComputers",
                c => new
                    {
                        Periphery_Id = c.Int(nullable: false),
                        Computer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Periphery_Id, t.Computer_Id })
                .ForeignKey("dbo.Peripheries", t => t.Periphery_Id, cascadeDelete: true)
                .ForeignKey("dbo.Computers", t => t.Computer_Id, cascadeDelete: true)
                .Index(t => t.Periphery_Id)
                .Index(t => t.Computer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeripheryComputers", "Computer_Id", "dbo.Computers");
            DropForeignKey("dbo.PeripheryComputers", "Periphery_Id", "dbo.Peripheries");
            DropIndex("dbo.PeripheryComputers", new[] { "Computer_Id" });
            DropIndex("dbo.PeripheryComputers", new[] { "Periphery_Id" });
            DropTable("dbo.PeripheryComputers");
        }
    }
}
