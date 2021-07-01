using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD_DAL.Migrations
{
    public partial class updateTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "tblColdDrinks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblColdDrinks",
                table: "tblColdDrinks",
                column: "intColdDrinksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblColdDrinks",
                table: "tblColdDrinks");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "tblColdDrinks",
                newName: "Foods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "intColdDrinksId");

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });
        }
    }
}
