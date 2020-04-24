using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TanulmanyiRendszer.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Szemeszterek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Megnevezes = table.Column<string>(nullable: true),
                    Kezdet = table.Column<DateTime>(nullable: false),
                    Veg = table.Column<DateTime>(nullable: false),
                    TargyjelentkezesKezdet = table.Column<DateTime>(nullable: false),
                    TargyJelentkezesVeg = table.Column<DateTime>(nullable: false),
                    VizsgajelentkezesKezdet = table.Column<DateTime>(nullable: false),
                    VizsgajelentkezesVeg = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szemeszterek", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Szemeszterek");
        }
    }
}
