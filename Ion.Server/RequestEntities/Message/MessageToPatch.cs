namespace Ion.Server.RequestEntities.Message;

public class MessageToPatch
{
    public string? Text { get; set; }
    public DateTimeOffset? CreationTime { get; set; }
}