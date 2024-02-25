using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitTracker.test.Migrations
{
    /// <inheritdoc />
    public partial class DeleteOnCascade2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayHabits_Habits_HabitId",
                table: "DayHabits");

            migrationBuilder.AddForeignKey(
                name: "FK_DayHabits_Habits_HabitId",
                table: "DayHabits",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayHabits_Habits_HabitId",
                table: "DayHabits");

            migrationBuilder.AddForeignKey(
                name: "FK_DayHabits_Habits_HabitId",
                table: "DayHabits",
                column: "HabitId",
                principalTable: "Habits",
                principalColumn: "Id");
        }
    }
}
