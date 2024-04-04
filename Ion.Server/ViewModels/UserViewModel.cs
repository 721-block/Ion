using Ion.Server.Common.Base;

namespace Ion.Server.ViewModels;

public class UserViewModel : BaseViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public int LicenseId { get; set; }
    public LicenseViewModel License { get; set; }
}
