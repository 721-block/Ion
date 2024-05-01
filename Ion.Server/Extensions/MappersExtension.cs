using Ion.Application.Mapper;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using Mapster;
using MapsterMapper;
using System.Reflection;

namespace Ion.Server.Extensions;

public static class MappersExtension
{
    public static IServiceCollection RegisterMapster(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Default.IgnoreNullValues(true);
        var registers = config.Scan(Assembly.GetAssembly(typeof(ViewModelRegister)));
        config.Apply(registers);
        services.AddSingleton(config);
        services.AddScoped<IMapper, Mapper>();
        return services;
    }
}