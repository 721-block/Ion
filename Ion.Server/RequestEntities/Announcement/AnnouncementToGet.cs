using Ion.Domain.Enums;
using Ion.Domain.ValueObjects;

namespace Ion.Server.RequestEntities.Announcement;

public class AnnouncementToGet
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public Coordinate CarLocation { get; set; }
    public int PricePerUnit { get; set; }
    public string? Description { get; set; }
    public string CarName { get; set; }
    public GearboxType CarGearboxType { get; set; }
    public BodyType CarBodyType { get; set; }
    public Day AvailableDays { get; set; }
    public bool IsActive { get; set; }
    public string PathToImages { get; set; }
    public float Rating { get; set; }
    public int ReviewsCount { get; set; }
}