namespace Ion.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public int AnnouncementId { get; set; }
    public int ClientId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}