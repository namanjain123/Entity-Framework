using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class totalcost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDetails_ExpenseHeaders_ExpenseHeaderId",
                table: "ExpenseDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseHeaderId",
                table: "ExpenseDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ToatalCost",
                table: "ExpenseDetails",
                type: "decimal(16,2",
                nullable: false,
                computedColumnSql: "[Quality]*[UniCost]");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDetails_ExpenseHeaders_ExpenseHeaderId",
                table: "ExpenseDetails",
                column: "ExpenseHeaderId",
                principalTable: "ExpenseHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDetails_ExpenseHeaders_ExpenseHeaderId",
                table: "ExpenseDetails");

            migrationBuilder.DropColumn(
                name: "ToatalCost",
                table: "ExpenseDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseHeaderId",
                table: "ExpenseDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDetails_ExpenseHeaders_ExpenseHeaderId",
                table: "ExpenseDetails",
                column: "ExpenseHeaderId",
                principalTable: "ExpenseHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
