using Ion.Server.RequestEntities.Announcement;

namespace Ion.Server.RequestEntities.Booking;

public class BookingToGet
{
    public int ClientId { get; set; }
    public string ClientFirstName { get; set; }
    public string ClientLastName { get; set; }
    public string ClientEmail { get; set; }
    public string ClientPhoneNumber { get; set; }
    public AnnouncementToGet Announcement { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
}