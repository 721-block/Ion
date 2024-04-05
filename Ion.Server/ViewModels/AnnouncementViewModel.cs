using Ion.Domain.Enums;
using Ion.Domain.ValueObjects;
using Ion.Server.Common.Base;

namespace Ion.Server.ViewModels;

public class AnnouncementViewModel : BaseViewModel
{
    public required Coordinate CarLocation { get; set; }
    public int PricePerUnit { get; set; }
    public string? Description { get; set; }
    public required string AuthorFirstName { get; set; }
    public required string AuthorLastName { get; set; }
    public string? AuthorEmail { get; set; }
    public string? AuthorPhoneNumber { get; set; }
    public required string CarName { get; set; }
    public GearboxType CarGearboxType { get; set; }
    public BodyType CarBodyType { get; set; }
    public Day AvailableDays { get; set; }
    public bool IsActive { get; set; }
    public string PathToImages { get; set; }
}
