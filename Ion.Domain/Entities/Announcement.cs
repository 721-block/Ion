using Ion.Domain.Common;
using Ion.Domain.Enums;
using NetTopologySuite.Geometries;

namespace Ion.Domain.Entities;

public class Announcement : BaseEntity<int>
{
    public Geometry CarLocation { get; set; }
    public int PricePerUnit { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public Day AvailableDays { get; set; }
    public string PathToImages { get; set; }
}