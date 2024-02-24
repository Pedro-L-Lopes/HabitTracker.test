using HabitTracker.test.Context;
using HabitTracker.test.Models;
using HabitTracker.test.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.test.Repository;
public class HabitRepository : IHabitRepository
{
    private readonly AppDbContext _context;

    public HabitRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Habit> Create(Habit habit)
    {
        _context.Habits.Add(habit);
        await _context.SaveChangesAsync();
        return habit;
    }

    public async Task<List<Habit>> GetHabitsForDay(DateTime date)
    {
       return await _context.Habits
        .Where(h => h.CreatedAt.Date <= date.Date && h.WeekDays.Any(w => w.WeekDay == (int)date.DayOfWeek))
        .ToListAsync();
    }

    public async Task<List<int?>> GetCompletedHabitsForDay(DateTime date)
    {
        return await _context.DayHabits
            .Where(dh => dh.Day.Date == date.Date)
            .Select(dh => dh.HabitId)
            .Distinct()
            .ToListAsync();
    }
}
