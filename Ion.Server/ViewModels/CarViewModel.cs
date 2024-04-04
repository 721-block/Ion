using Ion.Domain.Enums;
using Ion.Server.Common.Base;

namespace Ion.Server.ViewModels;

public class CarViewModel : BaseViewModel
{
    public GearboxType GearboxType { get; set; }
    public required string Name { get; set; }
    public BodyType BodyType { get; set; }
    public bool IsAnnounced { get; set; }
}
