using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionArch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class lessonDurationsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Lessons",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Courses",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalLessonDuration",
                table: "Courses",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TotalLessonDuration",
                table: "Courses");
        }
    }
}
