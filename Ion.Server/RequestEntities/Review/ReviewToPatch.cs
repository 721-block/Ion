namespace Ion.Server.RequestEntities.Review;

public class ReviewToPatch
{
    public string? UserFirstName { get; set; }
    public string? UserLastName { get; set; }
    public string? Content { get; set; }
    public float? Rating { get; set; }
    public DateTimeOffset? CreationDate { get; set; }
}