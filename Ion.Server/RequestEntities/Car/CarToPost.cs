using Ion.Domain.Enums;

namespace Ion.Server.RequestEntities.Car;

public class CarToPost
{
    public required int UserId { get; set; }
    public GearboxType? GearboxType { get; set; }
    public required string Name { get; set; }
    public BodyType? BodyType { get; set; }
    public bool IsAnnounced { get; set; }
}