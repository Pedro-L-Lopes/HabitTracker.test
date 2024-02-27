using HabitTracker.test.Context;
using HabitTracker.test.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.test.Repository;
public class UnityOfWork : IUnityOfWork
{
    public IHabitRepository? _habitRepository;
    public AppDbContext _context;

    public UnityOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IHabitRepository HabitRepository
    {
        get
        {
            return _habitRepository ??= new HabitRepository(_context);
        }
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
