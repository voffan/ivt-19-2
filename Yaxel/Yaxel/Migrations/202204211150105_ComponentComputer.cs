namespace Yaxel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComponentComputer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Components", "ComputerId", "dbo.Computers");
            DropForeignKey("dbo.Computers", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.Components", new[] { "ComputerId" });
            DropIndex("dbo.Computers", new[] { "ManufacturerId" });
            RenameColumn(table: "dbo.Computers", name: "ManufacturerId", newName: "Manufacturer_Id");
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
            
            AlterColumn("dbo.Computers", "Manufacturer_Id", c => c.Int());
            CreateIndex("dbo.Computers", "Manufacturer_Id");
            AddForeignKey("dbo.Computers", "Manufacturer_Id", "dbo.Manufacturers", "Id");
            DropColumn("dbo.Components", "ComputerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Components", "ComputerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Computers", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.ComputerComponents", "Component_Id", "dbo.Components");
            DropForeignKey("dbo.ComputerComponents", "Computer_Id", "dbo.Computers");
            DropIndex("dbo.ComputerComponents", new[] { "Component_Id" });
            DropIndex("dbo.ComputerComponents", new[] { "Computer_Id" });
            DropIndex("dbo.Computers", new[] { "Manufacturer_Id" });
            AlterColumn("dbo.Computers", "Manufacturer_Id", c => c.Int(nullable: false));
            DropTable("dbo.ComputerComponents");
            RenameColumn(table: "dbo.Computers", name: "Manufacturer_Id", newName: "ManufacturerId");
            CreateIndex("dbo.Computers", "ManufacturerId");
            CreateIndex("dbo.Components", "ComputerId");
            AddForeignKey("dbo.Computers", "ManufacturerId", "dbo.Manufacturers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Components", "ComputerId", "dbo.Computers", "Id", cascadeDelete: true);
        }
    }
}
