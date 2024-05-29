using Ion.Domain.Enums;
using Ion.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Ion.Server.RequestEntities.Announcement;

[BindProperties]
public class AnnouncementToPost
{
    public Coordinate CarLocation { get; set; } = new Coordinate() { X = 0, Y = 0 }; 
    public int PricePerUnit { get; set; }
    public string? Description { get; set; }
    public int AuthorId { get; set; }
    public int CarId { get; set; }
    public Day? AvailableDays { get; set; }
    public bool? IsActive { get; set; } = true;
    public List<IFormFile> Files { get; set; } = [];
}