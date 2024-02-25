using AutoMapper;
using HabitTracker.test.Models;

namespace HabitTracker.test.DTOs.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Habit, HabitDTO>().ReverseMap();
    }
}
