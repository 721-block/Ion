using Ion.Application.ViewModels;

namespace Ion.Server.RequestEntities.User;

public class UserToGet
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public LicenseViewModel? License { get; set; }
}