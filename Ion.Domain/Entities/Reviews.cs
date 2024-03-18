namespace Ion.Domain.Entities;

public class Reviews
{
    public int Id { get; set; }
    public int AnnouncementId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public float Rating { get; set; }
    public DateTime CreationDate { get; set; }
}