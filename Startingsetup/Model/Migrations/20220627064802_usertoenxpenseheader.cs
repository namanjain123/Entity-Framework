using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class usertoenxpenseheader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApproverId",
                table: "ExpenseHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequesterID",
                table: "ExpenseHeaders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpenseHeaderId",
                table: "ExpenseDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseHeaders_ApproverId",
                table: "ExpenseHeaders",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseHeaders_RequesterID",
                table: "ExpenseHeaders",
                column: "RequesterID");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetails_ExpenseHeaderId",
                table: "ExpenseDetails",
                column: "ExpenseHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseDetails_ExpenseHeaders_ExpenseHeaderId",
                table: "ExpenseDetails",
                column: "ExpenseHeaderId",
                principalTable: "ExpenseHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHeaders_Users_ApproverId",
                table: "ExpenseHeaders",
                column: "ApproverId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseHeaders_Users_RequesterID",
                table: "ExpenseHeaders",
                column: "RequesterID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseDetails_ExpenseHeaders_ExpenseHeaderId",
                table: "ExpenseDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHeaders_Users_ApproverId",
                table: "ExpenseHeaders");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseHeaders_Users_RequesterID",
                table: "ExpenseHeaders");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseHeaders_ApproverId",
                table: "ExpenseHeaders");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseHeaders_RequesterID",
                table: "ExpenseHeaders");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseDetails_ExpenseHeaderId",
                table: "ExpenseDetails");

            migrationBuilder.DropColumn(
                name: "ApproverId",
                table: "ExpenseHeaders");

            migrationBuilder.DropColumn(
                name: "RequesterID",
                table: "ExpenseHeaders");

            migrationBuilder.DropColumn(
                name: "ExpenseHeaderId",
                table: "ExpenseDetails");
        }
    }
}
