using HabitTracker.test.Models;

namespace HabitTracker.test.DTOs;
public class HabitWeekDaysDTO
{
    public int? Id { get; set; }
    public int? HabitId { get; set; }
    public int? WeekDay { get; set; }
    public Habit? Habit { get; set; }
}
