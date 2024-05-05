namespace Ion.Server.RequestEntities.Message;

public class MessageToPost
{
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string Text { get; set; }
    public DateTimeOffset CreationTime { get; set; }
}