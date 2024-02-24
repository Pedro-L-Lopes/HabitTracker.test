namespace HabitTracker.test.Models;
public class DayHabit
{
    public int? Id { get; set; }
    public int? DayId { get; set; }
    public int? HabitId { get; set; }
    public Day? Day { get; set; }
    public Habit? Habit { get; set; }
}
