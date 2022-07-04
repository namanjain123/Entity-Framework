using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class totalcosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ToatalCost",
                table: "ExpenseDetails",
                type: "decimal(16,2",
                nullable: false,
                computedColumnSql: "[Quanity]*[UniCost]",
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2",
                oldComputedColumnSql: "[Quality]*[UniCost]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ToatalCost",
                table: "ExpenseDetails",
                type: "decimal(16,2",
                nullable: false,
                computedColumnSql: "[Quality]*[UniCost]",
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2",
                oldComputedColumnSql: "[Quanity]*[UniCost]");
        }
    }
}
