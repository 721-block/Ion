using System.ComponentModel.DataAnnotations.Schema;

namespace Ion.Domain.ValueObjects;

[NotMapped]
public class Coordinate
{
    public double X { get; set; }
    public double Y { get; set; }
}