using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class addUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseDetails",
                columns: table => new
                {
                    ExpenseLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(16,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseDetails", x => x.ExpenseLineId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseDetails");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
