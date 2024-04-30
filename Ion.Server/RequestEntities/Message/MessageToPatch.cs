namespace Ion.Server.RequestEntities.Message;

public class MessageToPatch
{
    public string? SenderId { get; set; }
    public string? SenderFirstName { get; set; }
    public string? SenderLastName { get; set; }
    public string? ReceiverId { get; set; }
    public string? ReceiverFirstName { get; set; }
    public string? ReceiverLastName { get; set; }
    public string? Text { get; set; }
    public DateTimeOffset? CreationTime { get; set; }
}