using Ion.Domain.Common;

namespace Ion.Domain.Entities;

public class Booking : BaseEntity
{
    public int AnnouncementId { get; set; }
    public Announcement Announcement { get; set; }
    public int ClientId { get; set; }
    public User Client { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
}