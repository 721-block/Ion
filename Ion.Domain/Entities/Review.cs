using Ion.Domain.Common;

namespace Ion.Domain.Entities;

public class Review : BaseEntity
{
    public int AnnouncementId { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Content { get; set; }
    public float Rating { get; set; }
    public DateTimeOffset CreationDate { get; set; }
}