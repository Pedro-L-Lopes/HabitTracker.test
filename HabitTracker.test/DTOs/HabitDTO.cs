using HabitTracker.test.Models;
using System.ComponentModel.DataAnnotations;

namespace HabitTracker.test.DTOs;
public class HabitDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Insira o titulo do hábito")]
    public string? Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<DayHabit>? DayHabits { get; set; }
    public List<HabitWeekDays>? WeekDays { get; set; }
}
