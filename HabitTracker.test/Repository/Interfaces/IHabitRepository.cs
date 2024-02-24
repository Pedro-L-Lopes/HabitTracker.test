using HabitTracker.test.DTOs;
using HabitTracker.test.Models;

namespace HabitTracker.test.Repository.Interfaces;
public interface IHabitRepository
{
    Task<Habit> Create(Habit habit);
    Task<List<Habit>> GetHabitsForDay(DateTime date);
    Task<List<int?>> GetCompletedHabitsForDay(DateTime date);
    Task ToggleHabitForDay(int habitId, DateTime date);
    Task<List<SummaryDTO>> GetSummary();
}
