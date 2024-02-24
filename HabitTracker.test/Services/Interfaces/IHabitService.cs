using HabitTracker.test.DTOs;

namespace HabitTracker.test.Services.Interfaces;
public interface IHabitService
{
    Task AddHabit(HabitDTO habitDTO);
    Task<(List<HabitDTO> possibleHabits, List<int?> completedHabits)> GetHabitsForDay(string date);
    Task ToggleHabitForDay(int habitId, DateTime date);
    Task<List<SummaryDTO>> GetSummary();
}
