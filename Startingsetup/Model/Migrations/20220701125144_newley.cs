using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class newley : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHeaders_Users_RequesterID",
                table: "ExpenseHeaders");

            migrationBuilder.AddColumn<decimal>(
                name: "UsdExchangeRate",
                table: "ExpenseHeaders",
                type: "decimal(13,4",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                nullable: true,
                computedColumnSql: "[FirstName] + ' ' +[LastName]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComputedColumnSql: "[FirstName]+' '+[LastName]");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHeaders_Users_RequesterID",
                table: "ExpenseHeaders",
                column: "RequesterID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHeaders_Users_RequesterID",
                table: "ExpenseHeaders");

            migrationBuilder.DropColumn(
                name: "UsdExchangeRate",
                table: "ExpenseHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[FirstName]+' '+[LastName]",
                oldClrType: typeof(string),
                oldNullable: true,
                oldComputedColumnSql: "[FirstName] + ' ' +[LastName]");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHeaders_Users_RequesterID",
                table: "ExpenseHeaders",
                column: "RequesterID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
