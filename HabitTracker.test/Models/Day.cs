namespace HabitTracker.test.Models;
public class Day
{
    public int? Id { get; set; }
    public DateTime? Date { get; set; }
    public List<DayHabit>? DayHabits { get; set; }
}
