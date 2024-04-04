using Ion.Server.Common.Base;

namespace Ion.Server.ViewModels;

public class LicenseViewModel : BaseViewModel
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}
