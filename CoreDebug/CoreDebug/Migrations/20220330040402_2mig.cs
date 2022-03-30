using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace CoreDebug.Migrations
{
    public partial class _2mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paintings_Locations_LocationId",
                table: "Paintings");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Paintings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PaintingId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FromId = table.Column<int>(type: "int", nullable: false),
                    ToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journals_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Journals_Locations_FromId",
                        column: x => x.FromId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Journals_Locations_ToId",
                        column: x => x.ToId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Journals_Paintings_PaintingId",
                        column: x => x.PaintingId,
                        principalTable: "Paintings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Journals_EmployeeId",
                table: "Journals",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_FromId",
                table: "Journals",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_PaintingId",
                table: "Journals",
                column: "PaintingId");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_ToId",
                table: "Journals",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paintings_Locations_LocationId",
                table: "Paintings",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paintings_Locations_LocationId",
                table: "Paintings");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Paintings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Paintings_Locations_LocationId",
                table: "Paintings",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
