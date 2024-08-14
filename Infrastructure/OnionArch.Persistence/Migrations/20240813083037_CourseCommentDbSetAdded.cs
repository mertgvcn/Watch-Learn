using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionArch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CourseCommentDbSetAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseComment_Courses_CourseId",
                table: "CourseComment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseComment_Students_StudentId",
                table: "CourseComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseComment",
                table: "CourseComment");

            migrationBuilder.RenameTable(
                name: "CourseComment",
                newName: "CourseComments");

            migrationBuilder.RenameIndex(
                name: "IX_CourseComment_StudentId",
                table: "CourseComments",
                newName: "IX_CourseComments_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseComment_CourseId",
                table: "CourseComments",
                newName: "IX_CourseComments_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseComments",
                table: "CourseComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseComments_Courses_CourseId",
                table: "CourseComments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseComments_Students_StudentId",
                table: "CourseComments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseComments_Courses_CourseId",
                table: "CourseComments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseComments_Students_StudentId",
                table: "CourseComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseComments",
                table: "CourseComments");

            migrationBuilder.RenameTable(
                name: "CourseComments",
                newName: "CourseComment");

            migrationBuilder.RenameIndex(
                name: "IX_CourseComments_StudentId",
                table: "CourseComment",
                newName: "IX_CourseComment_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseComments_CourseId",
                table: "CourseComment",
                newName: "IX_CourseComment_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseComment",
                table: "CourseComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseComment_Courses_CourseId",
                table: "CourseComment",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseComment_Students_StudentId",
                table: "CourseComment",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
