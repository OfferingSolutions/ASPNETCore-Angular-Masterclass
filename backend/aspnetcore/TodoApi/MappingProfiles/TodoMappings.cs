using AutoMapper;
using TodoApi.Models;

namespace TodoApi.MappingProfiles 
{
    public class TodoMappings : Profile
    {
        public TodoMappings()
        {
            CreateMap<TodoEntity, TodoDto>().ReverseMap();
        }
    }
}
