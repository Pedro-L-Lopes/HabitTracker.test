using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HabitTracker.test.Migrations
{
    /// <inheritdoc />
    public partial class HabitsNotCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Habits",
                columns: new[] { "Id", "CreatedAt", "Title" },
                values: new object[,]
                {
                    { 4, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ler 30 minutos" },
                    { 5, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meditar" }
                });

            migrationBuilder.InsertData(
                table: "HabitWeekDays",
                columns: new[] { "Id", "HabitId", "WeekDay" },
                values: new object[,]
                {
                    { 12, 4, 1 },
                    { 13, 4, 2 },
                    { 14, 5, 4 },
                    { 15, 5, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HabitWeekDays",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "HabitWeekDays",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "HabitWeekDays",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "HabitWeekDays",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
