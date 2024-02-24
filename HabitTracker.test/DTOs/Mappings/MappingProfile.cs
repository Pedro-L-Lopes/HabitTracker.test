using AutoMapper;
using HabitTracker.test.Models;

namespace HabitTracker.test.DTOs.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Habit, HabitDTO>().ReverseMap();
        CreateMap<HabitWeekDays, HabitWeekDaysDTO>().ReverseMap();
        CreateMap<Day, DayDTO>().ReverseMap();
        CreateMap<DayHabit, DayHabitDTO>().ReverseMap();
    }
}
