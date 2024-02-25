using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitTracker.test.Migrations
{
    /// <inheritdoc />
    public partial class DeleteOnCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayHabits_Days_DayId",
                table: "DayHabits");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitWeekDays_Habits_HabitId",
                table: "HabitWeekDays");

            migrationBuilder.AddForeignKey(
                name: "FK_DayHabits_Days_DayId",
                table: "DayHabits",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HabitWeekDays_Habits_HabitId",
                table: "HabitWeekDays",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayHabits_Days_DayId",
                table: "DayHabits");

            migrationBuilder.DropForeignKey(
                name: "FK_HabitWeekDays_Habits_HabitId",
                table: "HabitWeekDays");

            migrationBuilder.AddForeignKey(
                name: "FK_DayHabits_Days_DayId",
                table: "DayHabits",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HabitWeekDays_Habits_HabitId",
                table: "HabitWeekDays",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id");
        }
    }
}
