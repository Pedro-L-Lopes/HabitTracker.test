using HabitTracker.test.Models;

namespace HabitTracker.test.Repository.Interfaces;
public interface IHabitRepository
{
    Task<Habit> Create(Habit habit);
    Task<List<Habit>> GetHabitsForDay(DateTime date);
}
