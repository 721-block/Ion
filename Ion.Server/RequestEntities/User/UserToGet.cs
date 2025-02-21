using Ion.Server.RequestEntities.License;

namespace Ion.Server.RequestEntities.User;

public class UserToGet
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public LicenseToGet License { get; set; }
    public string PathToPhoto { get; set; }
}