using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.MappingProfiles;

namespace TodoApi.Extensions 
{
    public static class MappingExtensions
    {
        public static void AddMappingProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TodoMappings));
        }
    }
}
