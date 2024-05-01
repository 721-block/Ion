using Ion.Application.Mapper;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using Mapster;
using System.Reflection;

namespace Ion.Server.Extensions;

public static class MappersExtension
{
    private static readonly TypeAdapterConfig config = new();
    public static IServiceCollection RegisterMapster(this IServiceCollection services)
    {
        config.Default.IgnoreNullValues(true);
        var registers = config.Scan(Assembly.GetAssembly(typeof(ViewModelRegister)));
        config.Apply(registers);
        services.AddMapster();
        return services;
    }
}