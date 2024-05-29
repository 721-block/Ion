namespace Ion.Application.ViewModels;

public class ReviewViewModel : BaseViewModel
{
    public int? UserId { get; set; }
    public int? AnnouncementId { get; set; }
    public string? UserFirstName { get; set; }
    public string? UserLastName { get; set; }
    public string? Content { get; set; }
    public float? Rating { get; set; }
    public string? UserPathToPhoto { get; set; }
    public DateTimeOffset? CreationDate { get; set; }
}