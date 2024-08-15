using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionArch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LessonNumberAddedToLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "LessonNumber",
                table: "Lessons",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonNumber",
                table: "Lessons");
        }
    }
}
