using Ion.Server.Common.Base;

namespace Ion.Server.ViewModels;

public class BookingViewModel : BaseViewModel
{
    public int AnnouncementPricePerUnit {  get; set; }
    public required string AuthorFirstName { get; set; }
    public required string AuthorLastName { get; set; }
    public required AnnouncementViewModel Announcement { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
}
