using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD_DAL.Migrations
{
    public partial class AddtblAkijFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    intColdDrinksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strColdDrinksName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    numUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.intColdDrinksId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
