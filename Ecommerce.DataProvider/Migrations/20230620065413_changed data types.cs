using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class changeddatatypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "RegisterUserAddress_state",
                table: "registerUsersAddress",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterUserAddress_country",
                table: "registerUsersAddress",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterUserAddress_city",
                table: "registerUsersAddress",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterUserAddress_PostalCode",
                table: "registerUsersAddress",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RegisterUserAddress_PhoneNumber",
                table: "registerUsersAddress",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AddressRegisterUserAddress_ID",
                table: "registerUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_registerUsers_AddressRegisterUserAddress_ID",
                table: "registerUsers",
                column: "AddressRegisterUserAddress_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_registerUsers_registerUsersAddress_AddressRegisterUserAddress_ID",
                table: "registerUsers",
                column: "AddressRegisterUserAddress_ID",
                principalTable: "registerUsersAddress",
                principalColumn: "RegisterUserAddress_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registerUsers_registerUsersAddress_AddressRegisterUserAddress_ID",
                table: "registerUsers");

            migrationBuilder.DropIndex(
                name: "IX_registerUsers_AddressRegisterUserAddress_ID",
                table: "registerUsers");

            migrationBuilder.DropColumn(
                name: "AddressRegisterUserAddress_ID",
                table: "registerUsers");

            migrationBuilder.AlterColumn<int>(
                name: "RegisterUserAddress_state",
                table: "registerUsersAddress",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "RegisterUserAddress_country",
                table: "registerUsersAddress",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "RegisterUserAddress_city",
                table: "registerUsersAddress",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "RegisterUserAddress_PostalCode",
                table: "registerUsersAddress",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "RegisterUserAddress_PhoneNumber",
                table: "registerUsersAddress",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
