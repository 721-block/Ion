using Ion.Application.Mapper;
using Mapster;
using MapsterMapper;
using System.Reflection;

namespace Ion.Tests.Common;

public static class AddMapsterForUnitTests
{
    private static readonly TypeAdapterConfig config = new();
    public static Mapper GetMapper()
    {
        config.Default.IgnoreNullValues(true);
        var registers = config.Scan(Assembly.GetAssembly(typeof(ViewModelRegister)));
        config.Apply(registers);
        return new Mapper(config);
    }
}
