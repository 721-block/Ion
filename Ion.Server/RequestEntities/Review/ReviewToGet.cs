namespace Ion.Server.RequestEntities.Review;

public class ReviewToGet
{
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public int UserId { get; set; }
    public string UserPathToPhoto { get; set; }
    public string Content { get; set; }
    public float Rating { get; set; }
    public DateTimeOffset CreationDate { get; set; }
}