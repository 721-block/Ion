using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.User;

namespace Ion.Server.RequestEntities.Message;

public class MessageToGet
{
    public UserToGet Sender { get; set; }
    public UserToGet Receiver { get; set; }
    public AnnouncementToGet Announcement { get; set; }
    public string Text { get; set; }
    public DateTimeOffset CreationTime { get; set; }
}