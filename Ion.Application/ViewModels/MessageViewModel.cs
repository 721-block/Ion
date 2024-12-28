namespace Ion.Application.ViewModels;

public class MessageViewModel : BaseViewModel
{
    public UserViewModel? Sender { get; set; }
    public UserViewModel? Receiver { get; set; }
    public AnnouncementViewModel? Announcement { get; set; }
    public string? Text { get; set; }
    public DateTimeOffset? CreationTime { get; set; }
}