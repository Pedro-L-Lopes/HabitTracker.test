using HabitTracker.test.Models;

namespace HabitTracker.test.DTOs;
public class DayDTO
{
    public int? Id { get; set; }
    public DateTime? Date { get; set; }
    public List<DayHabit>? DayHabits { get; set; }
}
