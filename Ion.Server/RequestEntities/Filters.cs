using Ion.Domain.Enums;

namespace Ion.Server.RequestEntities;

public class FilterParameters
{
    public GearboxType GearboxType { get; set; }
    public BodyType BodyType { get; set; }
    public string CarName { get; set; }
    public int Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}