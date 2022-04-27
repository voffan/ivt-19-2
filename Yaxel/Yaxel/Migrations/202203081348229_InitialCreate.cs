namespace Yaxel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        ComputerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Computers", t => t.ComputerId, cascadeDelete: true)
                .Index(t => t.ComputerId);
            
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Status = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ManufacturerId);
            
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
                        EmployeeId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Peripheries", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Computers", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Peripheries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Computers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Components", "ComputerId", "dbo.Computers");
            DropForeignKey("dbo.Attributes", "ComponentId", "dbo.Components");
            DropIndex("dbo.Peripheries", new[] { "ManufacturerId" });
            DropIndex("dbo.Peripheries", new[] { "EmployeeId" });
            DropIndex("dbo.Computers", new[] { "ManufacturerId" });
            DropIndex("dbo.Computers", new[] { "EmployeeId" });
            DropIndex("dbo.Components", new[] { "ComputerId" });
            DropIndex("dbo.Attributes", new[] { "ComponentId" });
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Peripheries");
            DropTable("dbo.Employees");
            DropTable("dbo.Computers");
            DropTable("dbo.Components");
            DropTable("dbo.Attributes");
        }
    }
}
