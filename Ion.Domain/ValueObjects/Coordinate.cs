using System.ComponentModel.DataAnnotations.Schema;

namespace Ion.Domain.ValueObjects;

[NotMapped]
public record Coordinate(double X, double Y)
{
}