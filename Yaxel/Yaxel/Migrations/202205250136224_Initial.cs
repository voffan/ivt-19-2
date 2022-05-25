namespace Yaxel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        AttrType = c.Int(nullable: false),
                        ComponentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .Index(t => t.ComponentId);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(maxLength: 50),
                        ComponentType = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Status = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Login = c.String(),
                        Password = c.String(),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Peripheries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(maxLength: 50),
                        PeripheryType = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComputerComponents",
                c => new
                    {
                        Computer_Id = c.Int(nullable: false),
                        Component_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Computer_Id, t.Component_Id })
                .ForeignKey("dbo.Computers", t => t.Computer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Components", t => t.Component_Id, cascadeDelete: true)
                .Index(t => t.Computer_Id)
                .Index(t => t.Component_Id);
            
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
            DropForeignKey("dbo.Peripheries", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Components", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.PeripheryComputers", "Computer_Id", "dbo.Computers");
            DropForeignKey("dbo.PeripheryComputers", "Periphery_Id", "dbo.Peripheries");
            DropForeignKey("dbo.Computers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ComputerComponents", "Component_Id", "dbo.Components");
            DropForeignKey("dbo.ComputerComponents", "Computer_Id", "dbo.Computers");
            DropForeignKey("dbo.Attributes", "ComponentId", "dbo.Components");
            DropIndex("dbo.PeripheryComputers", new[] { "Computer_Id" });
            DropIndex("dbo.PeripheryComputers", new[] { "Periphery_Id" });
            DropIndex("dbo.ComputerComponents", new[] { "Component_Id" });
            DropIndex("dbo.ComputerComponents", new[] { "Computer_Id" });
            DropIndex("dbo.Peripheries", new[] { "ManufacturerId" });
            DropIndex("dbo.Computers", new[] { "EmployeeId" });
            DropIndex("dbo.Components", new[] { "ManufacturerId" });
            DropIndex("dbo.Attributes", new[] { "ComponentId" });
            DropTable("dbo.PeripheryComputers");
            DropTable("dbo.ComputerComponents");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Peripheries");
            DropTable("dbo.Employees");
            DropTable("dbo.Computers");
            DropTable("dbo.Components");
            DropTable("dbo.Attributes");
        }
    }
}
