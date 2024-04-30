using Ion.Domain.Enums;
using Ion.Domain.ValueObjects;

namespace Ion.Server.RequestEntities.Announcement;

public class AnnouncementToPatch
{
    public required Coordinate? CarLocation { get; set; }
    public int? PricePerUnit { get; set; }
    public string? Description { get; set; }
    public int? AuthorId { get; set; }
    public int? CarId { get; set; }
    public Day? AvailableDays { get; set; }
    public bool? IsActive { get; set; }
    public string? PathToImages { get; set; }
}