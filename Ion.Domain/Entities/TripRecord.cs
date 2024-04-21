using Ion.Domain.Common;

namespace Ion.Domain.Entities;

public class TripRecord : BaseEntity
{
    public int UserId { get; set; }
    public int AnnouncementId { get; set; }
    public Announcement Announcement { get; set; }
}