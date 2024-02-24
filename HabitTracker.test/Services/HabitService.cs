using AutoMapper;
using HabitTracker.test.DTOs;
using HabitTracker.test.Models;
using HabitTracker.test.Repository.Interfaces;
using HabitTracker.test.Services.Interfaces;

namespace HabitTracker.test.Services;
public class HabitService : IHabitService
{
    private readonly IHabitRepository _habitRepository;
    private readonly IMapper _mapper;

    public HabitService(IHabitRepository habitRepository, IMapper mapper)
    {
        _habitRepository = habitRepository;
        _mapper = mapper;
    }

    public async Task AddHabit(HabitDTO habitDTO)
    {
        var habitEntity = new Habit
        {
            Title = habitDTO.Title,
            CreatedAt = DateTime.Now.Date,
            WeekDays = habitDTO.WeekDays.Select(day => new HabitWeekDays { WeekDay = day }).ToList()
        };
        await _habitRepository.Create(habitEntity);
    }

    public async Task<List<HabitDTO>> GetHabitsForDay(string date)
    {
        if (!DateTime.TryParse(date, out DateTime parsedDate))
            throw new ArgumentException("Formato de data inválido");

        var habits = await _habitRepository.GetHabitsForDay(parsedDate);

        return _mapper.Map<List<Habit>, List<HabitDTO>>(habits);
    }
}
