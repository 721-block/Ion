namespace Ion.Application.ViewModels;

public class BookingViewModel : BaseViewModel
{
    public int? ClientId { get; set; }
    public string? ClientFirstName { get; set; }
    public string? ClientLastName { get; set; }
    public string? ClientEmail { get; set; }
    public string? ClientPhoneNumber { get; set; }
    public int? AnnouncementId { get; set; }
    public AnnouncementViewModel? Announcement { get; set; }
    public DateTimeOffset? StartTime { get; set; }
    public DateTimeOffset? EndTime { get; set; }
}