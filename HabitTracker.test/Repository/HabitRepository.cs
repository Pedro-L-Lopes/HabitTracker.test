using HabitTracker.test.Context;
using HabitTracker.test.DTOs;
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

    public async Task ToggleHabitForDay(int habitId, DateTime date)
    {
        var day = await _context.Days.FirstOrDefaultAsync(d => d.Date == date);

        if (day == null)
        {
            day = new Day { Date = date };
            _context.Days.Add(day);
            await _context.SaveChangesAsync();
        }

        var existingDayHabit = await _context.DayHabits
            .FirstOrDefaultAsync(dh => dh.DayId == day.Id && dh.HabitId == habitId);

        if (existingDayHabit != null)
        {
            _context.DayHabits.Remove(existingDayHabit);
        }
        else
        {
            var newDayHabit = new DayHabit { DayId = day.Id, HabitId = habitId };
            _context.DayHabits.Add(newDayHabit);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<List<SummaryDTO>> GetSummary()
    {
        var summary = await _context.Days
            .Select(d => new SummaryDTO
            {
                Id = d.Id,
                Date = d.Date,
                Completed = d.DayHabits.Count,
                Amount = _context.HabitWeekDays
                    .Count(hwd => d.Date.HasValue && hwd.WeekDay == (int)d.Date.Value.DayOfWeek)
            })
            .ToListAsync();

        return summary;
    }

}
