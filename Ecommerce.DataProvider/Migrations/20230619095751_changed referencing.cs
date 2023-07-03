using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class changedreferencing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registerUsers_registerUsersAddress_RegisterUserAddress_ID",
                table: "registerUsers");

            migrationBuilder.DropIndex(
                name: "IX_registerUsers_RegisterUserAddress_ID",
                table: "registerUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "registerUsersAddress");

            migrationBuilder.DropColumn(
                name: "RegisterUserAddress_ID",
                table: "registerUsers");

            migrationBuilder.AddColumn<int>(
                name: "RegisterUserUserId",
                table: "registerUsersAddress",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_registerUsersAddress_RegisterUserUserId",
                table: "registerUsersAddress",
                column: "RegisterUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_registerUsersAddress_registerUsers_RegisterUserUserId",
                table: "registerUsersAddress",
                column: "RegisterUserUserId",
                principalTable: "registerUsers",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registerUsersAddress_registerUsers_RegisterUserUserId",
                table: "registerUsersAddress");

            migrationBuilder.DropIndex(
                name: "IX_registerUsersAddress_RegisterUserUserId",
                table: "registerUsersAddress");

            migrationBuilder.DropColumn(
                name: "RegisterUserUserId",
                table: "registerUsersAddress");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "registerUsersAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegisterUserAddress_ID",
                table: "registerUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_registerUsers_RegisterUserAddress_ID",
                table: "registerUsers",
                column: "RegisterUserAddress_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_registerUsers_registerUsersAddress_RegisterUserAddress_ID",
                table: "registerUsers",
                column: "RegisterUserAddress_ID",
                principalTable: "registerUsersAddress",
                principalColumn: "RegisterUserAddress_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
