using Ion.Domain.Enums;
using Ion.Domain.ValueObjects;

namespace Ion.Server.RequestEntities.Announcement;

public class AnnouncementToGet
{
    public Coordinate CarLocation { get; set; }
    public int PricePerUnit { get; set; }
    public string? Description { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorLastName { get; set; }
    public string AuthorEmail { get; set; }
    public string AuthorPhoneNumber { get; set; }
    public string CarName { get; set; }
    public GearboxType CarGearboxType { get; set; }
    public BodyType CarBodyType { get; set; }
    public Day AvailableDays { get; set; }
    public bool IsActive { get; set; }
    public string PathToImages { get; set; }
}