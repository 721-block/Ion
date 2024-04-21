namespace Ion.Application.ViewModels;

public class TripRecordViewModel : BaseViewModel
{
    public string Description { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorLastName { get; set; }
    public string CarName { get; set; }
    public int PricePerUnit { get; set; }
    public int AnnouncementId { get; set; }
    public string PathToImages { get; set; }
}