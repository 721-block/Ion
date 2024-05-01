using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using Ion.Domain.Enums;
using Ion.Tests.Common;
using MapsterMapper;

namespace Ion.Tests;

public class MapperTests
{
    private IMapper mapper;

    [SetUp]
    public void Setup()
    {
        mapper = AddMapsterForUnitTests.GetMapper();
    }

    [Test]
    public void ChangeCurrentCar()
    {
        var car = new Car()
        {
            Id = 0,
            BodyType = BodyType.Crossover,
            IsAnnounced = true,
            Name = "Lada",
            GearboxType = GearboxType.Stepless,
            UserId = 5
        };

        var carViewModel = new CarViewModel()
        {
            Id = 0,
            Name = "Test"
        };

        var newCar = mapper.Map(carViewModel, car);

        var rightCar = new Car()
        {
            Id = 0,
            BodyType = BodyType.Crossover,
            IsAnnounced = true,
            Name = "Test",
            GearboxType = GearboxType.Stepless,
            UserId = 5
        };
        Assert.Equals(rightCar, newCar);
    }
}