namespace Ion.Application.ViewModels;

public class BookingViewModel : BaseViewModel
{
    public required string ClientFirstName { get; set; }
    public required string ClientLastName { get; set; }
    public string ClientEmail { get; set; }
    public string ClientPhoneNumber { get; set; }
    public required AnnouncementViewModel Announcement { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
}
