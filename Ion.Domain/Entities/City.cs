using Ion.Domain.Common;

namespace Ion.Domain.Entities;

public class City(string name) : BaseEntity<int>
{
    public string Name { get; set; } = string.IsNullOrWhiteSpace(name) ? string.Empty : name;

    public static implicit operator string(City city)
    {
        return city.Name;
    }
}