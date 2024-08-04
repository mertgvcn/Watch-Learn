using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OnionArch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class infiniteCycleSolvedOnModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentLessonProgresses",
                table: "StudentLessonProgresses");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "StudentLessonProgresses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentLessonProgresses",
                table: "StudentLessonProgresses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLessonProgresses_StudentId",
                table: "StudentLessonProgresses",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentLessonProgresses",
                table: "StudentLessonProgresses");

            migrationBuilder.DropIndex(
                name: "IX_StudentLessonProgresses_StudentId",
                table: "StudentLessonProgresses");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "StudentLessonProgresses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentLessonProgresses",
                table: "StudentLessonProgresses",
                columns: new[] { "StudentId", "LessonId" });
        }
    }
}
