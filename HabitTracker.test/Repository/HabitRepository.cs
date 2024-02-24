using HabitTracker.test.Context;
using HabitTracker.test.Models;
using HabitTracker.test.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

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
}
