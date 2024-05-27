using System.Collections;
using Ion.Domain.Common;

namespace Ion.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string HashPassword { get; set; }
    public string PhoneNumber { get; set; }
    public int? LicenseId { get; set; }
    public License License { get; set; }
    public string PathToPhoto { get; set; }
    public virtual ICollection<Booking> UserBookings { get; set; }
    public virtual ICollection<Message> SendedMessages { get; set; }
    public virtual ICollection<Message> RecievedMessages { get; set; }
    public virtual ICollection<Announcement> Announcements { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<TripRecord> TripRecords { get; set; }
}