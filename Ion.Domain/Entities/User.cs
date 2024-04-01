using Ion.Domain.Common;

namespace Ion.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public int LicenseId { get; set; }
    public License License { get; set; }
}