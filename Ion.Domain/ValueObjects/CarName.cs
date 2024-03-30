using Ion.Domain.Common;

namespace Ion.Domain.ValueObjects;

public record CarName(string name)
{
    public string Name { get; private set; } = string.IsNullOrWhiteSpace(name) ? string.Empty : name;
}