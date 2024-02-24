using HabitTracker.test.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HabitTracker.test.DTOs;
public class HabitDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Insira o titulo do hábito")]
    public string? Title { get; set; }
    public DateTime CreatedAt { get; set; }

    [JsonIgnore]
    public List<DayHabit>? DayHabits { get; set; }

    public List<int>? WeekDays { get; set; }
}
