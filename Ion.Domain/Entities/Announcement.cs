using Ion.Domain.Common;
using Ion.Domain.Enums;
using Ion.Domain.ValueObjects;

namespace Ion.Domain.Entities;

public class Announcement : BaseEntity<int>
{
    public City City { get; set; }
    public CarName CarName { get; set; } 
    public BodyType BodyType { get; set; }
    public int Price { get; set; }
    public GearboxType GearboxType { get; set; }
}