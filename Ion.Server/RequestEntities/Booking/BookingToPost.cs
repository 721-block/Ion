using Ion.Server.RequestEntities.Announcement;

namespace Ion.Server.RequestEntities.Bookings;

public class BookingToPost
{
    public required int ClientId { get; set; }
    public required string ClientFirstName { get; set; }
    public required string ClientLastName { get; set; }
    public string? ClientEmail { get; set; }
    public string? ClientPhoneNumber { get; set; }
    public required AnnouncementToPost Announcement { get; set; }
    public DateTimeOffset? StartTime { get; set; }
    public DateTimeOffset? EndTime { get; set; }
}