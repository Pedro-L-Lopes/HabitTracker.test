namespace HabitTracker.test.Models;
public class Habit
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<DayHabit>? DayHabits { get; set; }
    public List<HabitWeekDays>? WeekDays { get; set; }
}
