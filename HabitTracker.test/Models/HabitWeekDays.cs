namespace HabitTracker.test.Models;
public class HabitWeekDays
{
    public int? Id { get; set; }
    public int? HabitId { get; set; }
    public int? WeekDay { get; set; }
    public Habit? Habit { get; set; }
}
