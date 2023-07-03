using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.DataProvider.Migrations
{
    /// <inheritdoc />
    public partial class addingregisteruserandregisteruseraddresstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "registerUsersAddress",
                columns: table => new
                {
                    RegisterUserAddress_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RegisterUserAddress_country = table.Column<int>(type: "int", nullable: false),
                    RegisterUserAddress_state = table.Column<int>(type: "int", nullable: false),
                    RegisterUserAddress_city = table.Column<int>(type: "int", nullable: false),
                    RegisterUserAddress_PostalCode = table.Column<int>(type: "int", nullable: false),
                    RegisterUserAddress_PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registerUsersAddress", x => x.RegisterUserAddress_ID);
                });

            migrationBuilder.CreateTable(
                name: "registerUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    registeredOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ForgetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterUserAddress_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registerUsers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_registerUsers_registerUsersAddress_RegisterUserAddress_ID",
                        column: x => x.RegisterUserAddress_ID,
                        principalTable: "registerUsersAddress",
                        principalColumn: "RegisterUserAddress_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_registerUsers_RegisterUserAddress_ID",
                table: "registerUsers",
                column: "RegisterUserAddress_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registerUsers");

            migrationBuilder.DropTable(
                name: "registerUsersAddress");
        }
    }
}
