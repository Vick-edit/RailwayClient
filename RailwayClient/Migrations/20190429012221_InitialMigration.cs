using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RailwayClient.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Railways",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    TelegraphName = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Railways", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RailwayId = table.Column<int>(nullable: true),
                    Id = table.Column<int>(nullable: false),
                    RailwayDepartmentId = table.Column<int>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    Name12Char = table.Column<string>(maxLength: 12, nullable: true),
                    Name = table.Column<string>(maxLength: 40, nullable: true),
                    FreightSign = table.Column<bool>(nullable: false),
                    CodeOSGD = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Stations_Railways_RailwayId",
                        column: x => x.RailwayId,
                        principalTable: "Railways",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stations_RailwayId",
                table: "Stations",
                column: "RailwayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Railways");
        }
    }
}
