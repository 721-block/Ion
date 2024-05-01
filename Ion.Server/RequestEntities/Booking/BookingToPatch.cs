using Ion.Server.RequestEntities.Announcement;

namespace Ion.Server.RequestEntities.Bookings;

public class BookingToPatch
{
    public int? ClientId { get; set; }
    public int? AnnouncementId { get; set; }
    public DateTimeOffset? StartTime { get; set; }
    public DateTimeOffset? EndTime { get; set; }
}