using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgriEnergyConnect.Migrations
{
    /// <inheritdoc />
    public partial class FixUserTableMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Farmers_FarmerId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Users_FarmerId",
                table: "User",
                newName: "IX_User_FarmerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Farmers_FarmerId",
                table: "User",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Farmers_FarmerId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_User_FarmerId",
                table: "Users",
                newName: "IX_Users_FarmerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Farmers_FarmerId",
                table: "Users",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId");
        }
    }
}
