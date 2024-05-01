namespace Ion.Server.RequestEntities.Bookings;

public class BookingToPost
{
    public required int ClientId { get; set; }
    public required int AnnouncementId { get; set; }
    public DateTimeOffset? StartTime { get; set; }
    public DateTimeOffset? EndTime { get; set; }
}