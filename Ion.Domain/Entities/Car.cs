using Ion.Domain.Common;
using Ion.Domain.Enums;
using Ion.Domain.ValueObjects;

namespace Ion.Domain.Entities;

public class Car : BaseEntity
{
    public int UserId { get; set; }
    public GearboxType GearboxType { get; set; }
    public string Name { get; set; } 
    public BodyType BodyType { get; set; }
    public bool IsAnnounced { get; set; }
}