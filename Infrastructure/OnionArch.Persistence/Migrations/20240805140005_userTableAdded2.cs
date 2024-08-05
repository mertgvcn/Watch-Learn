using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionArch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userTableAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Students_StudentId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Teachers_TeacherId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_User_TeacherId",
                table: "Users",
                newName: "IX_Users_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_User_StudentId",
                table: "Users",
                newName: "IX_Users_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Students_StudentId",
                table: "Users",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teachers_TeacherId",
                table: "Users",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Students_StudentId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teachers_TeacherId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TeacherId",
                table: "User",
                newName: "IX_User_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_StudentId",
                table: "User",
                newName: "IX_User_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Students_StudentId",
                table: "User",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Teachers_TeacherId",
                table: "User",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
