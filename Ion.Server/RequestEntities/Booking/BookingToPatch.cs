using Ion.Server.RequestEntities.Announcement;

namespace Ion.Server.RequestEntities.Bookings;

public class BookingToPatch
{
    public int? ClientId { get; set; }
    public string? ClientFirstName { get; set; }
    public string? ClientLastName { get; set; }
    public string? ClientEmail { get; set; }
    public string? ClientPhoneNumber { get; set; }
    public AnnouncementToPatch? Announcement { get; set; }
    public DateTimeOffset? StartTime { get; set; }
    public DateTimeOffset? EndTime { get; set; }
}