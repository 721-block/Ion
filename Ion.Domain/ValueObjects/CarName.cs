using Ion.Domain.Common;

namespace Ion.Domain.ValueObjects
{
    public class CarName(string name) : ValueObject
    {
        public string Name { get; private set; } = string.IsNullOrWhiteSpace(name) ? string.Empty : name;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
