using Ion.Domain.Common;
using Ion.Domain.Enums;
using Ion.Domain.ValueObjects;

namespace Ion.Domain.Entities;

public class Car : BaseEntity<int>
{
    public GearboxType GearboxType { get; set; }
    public CarName CarName { get; set; } 
    public BodyType BodyType { get; set; }
}