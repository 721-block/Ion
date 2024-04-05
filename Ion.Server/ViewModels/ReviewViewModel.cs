using Ion.Server.Common.Base;

namespace Ion.Server.ViewModels;

public class ReviewViewModel : BaseViewModel
{
    public required string UserFirstName { get; set; }
    public required string UserLastName { get; set; }
    public string Content { get; set; }
    public float Rating { get; set; }
    public DateTime CreationDate { get; set; }
}
