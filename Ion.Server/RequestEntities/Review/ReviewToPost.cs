namespace Ion.Server.RequestEntities.Review;

public class ReviewToPost
{
    public int UserId { get; set; }
    public int AnnouncementId { get; set; }
    public string Content { get; set; }
    public float Rating { get; set; }
    public DateTimeOffset CreationDate { get; set; }
}