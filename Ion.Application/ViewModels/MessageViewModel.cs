namespace Ion.Application.ViewModels;

public class MessageViewModel : BaseViewModel
{
    public int? SenderId { get; set; }
    public UserViewModel? Sender { get; set; }
    public int? ReceiverId { get; set; }
    public UserViewModel? Receiver { get; set; }
    public int? AnnouncementId { get; set; }
    public AnnouncementViewModel? Announcement { get; set; }
    public string? Text { get; set; }
    public DateTimeOffset? CreationTime { get; set; }
}