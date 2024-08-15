using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionArch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class videoUrlAddedToLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCompleted",
                table: "StudentLessonProgresses");

            migrationBuilder.AddColumn<string>(
                name: "VideoURL",
                table: "Lessons",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoURL",
                table: "Lessons");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompleted",
                table: "StudentLessonProgresses",
                type: "timestamp without time zone",
                nullable: true);
        }
    }
}
