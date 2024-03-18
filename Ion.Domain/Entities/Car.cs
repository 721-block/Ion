using Ion.Domain.Enums;
using Ion.Domain.ValueObjects;

namespace Ion.Domain.Entities;

public class Car
{
    public int Id { get; set; }
    public GearboxType GearboxType { get; set; }
    public CarName CarName { get; set; } 
    public BodyType BodyType { get; set; }
}