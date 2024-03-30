using Ion.Domain.Common;
using Ion.Domain.Enums;

namespace Ion.Domain.Entities;

public class Announcement : BaseEntity
{
    public Coordinate CarLocation { get; set; }
    public int PricePerUnit { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
    public Day AvailableDays { get; set; }
    public bool IsActive { get; set; }
    public string PathToImages { get; set; }
}