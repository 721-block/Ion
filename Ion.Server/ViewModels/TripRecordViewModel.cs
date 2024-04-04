using Ion.Domain.Entities;
using Ion.Domain.Enums;
using Ion.Domain.ValueObjects;
using Ion.Server.Common.Base;

namespace Ion.Server.ViewModels;

public class TripRecordViewModel : BaseViewModel
{
    public string Description { get; set; }
    public string AuthorFirstName {  get; set; }
    public string AuthorLastName { get; set; }
    public string CarName { get; set; }
    public int PricePerUnit { get; set; }
    public int AnnouncementId { get; set; }
    public string PathToImages { get; set; }
}
