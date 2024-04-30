using Ion.Domain.Enums;

namespace Ion.Server.RequestEntities.Car;

public class CarToPatch
{
    public GearboxType? GearboxType { get; set; }
    public string? Name { get; set; }
    public BodyType? BodyType { get; set; }
    public bool? IsAnnounced { get; set; }
}