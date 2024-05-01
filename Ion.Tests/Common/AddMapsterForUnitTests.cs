using Ion.Application.Mapper;
using Mapster;
using MapsterMapper;
using System.Reflection;

namespace Ion.Tests.Common;

public static class AddMapsterForUnitTests
{
    public static Mapper GetMapper()
    {
        var config = TypeAdapterConfig.GlobalSettings;
        var registers = config.Scan(Assembly.GetAssembly(typeof(ViewModelRegister)));
        config.Apply(registers);
        return new Mapper(config);
    }
}
