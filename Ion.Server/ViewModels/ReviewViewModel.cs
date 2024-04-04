using Ion.Server.Common.Base;

namespace Ion.Server.ViewModels;

public class ReviewViewModel : BaseViewModel
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string Content { get; set; }
    public float Rating { get; set; }
    public DateTime CreationDate { get; set; }
}
