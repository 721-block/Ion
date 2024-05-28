using Ion.Server.RequestEntities.License;

namespace Ion.Server.RequestEntities.User;

public class UserToPost
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public LicenseToPost? License { get; set; }
    public string? PathToPhoto { get; set; }
}