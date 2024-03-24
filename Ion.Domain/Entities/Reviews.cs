using Ion.Domain.Common;

namespace Ion.Domain.Entities;

public class Reviews : BaseEntity
{
    public int AnnouncementId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public float Rating { get; set; }
    public DateTime CreationDate { get; set; }
}