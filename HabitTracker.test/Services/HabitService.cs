using AutoMapper;
using HabitTracker.test.DTOs;
using HabitTracker.test.Models;
using HabitTracker.test.Repository.Interfaces;
using HabitTracker.test.Services.Interfaces;

namespace HabitTracker.test.Services;
public class HabitService : IHabitService
{
    private readonly IUnityOfWork _uof;
    private readonly IMapper _mapper;

    public HabitService(IUnityOfWork uof, IMapper mapper)
    {
        _uof = uof;
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
        await _uof.HabitRepository.Create(habitEntity);
    }

    public async Task<(List<HabitDTO> possibleHabits, List<int?> completedHabits)> GetHabitsForDay(string date)
    {
        if (!DateTime.TryParse(date, out DateTime parsedDate))
            throw new ArgumentException("Formato de data inválido");

        // Consulta para encontrar hábitos válidos para o dia especificado
        var possibleHabits = await _uof.HabitRepository.GetHabitsForDay(parsedDate);

        // Consulta para encontrar os hábitos completados para o dia especificado
        var completedHabits = await _uof.HabitRepository.GetCompletedHabitsForDay(parsedDate);

        return (_mapper.Map<List<Habit>, List<HabitDTO>>(possibleHabits), completedHabits);
    }

    public async Task ToggleHabitForDay(int habitId, DateTime date)
    {
        await _uof.HabitRepository.ToggleHabitForDay(habitId, date);
    }

    public async Task<List<SummaryDTO>> GetSummary()
    {
        return await _uof.HabitRepository.GetSummary();
    }

    public async Task Delete(int habitId)
    {
        await _uof.HabitRepository.Delete(habitId);
    }
}