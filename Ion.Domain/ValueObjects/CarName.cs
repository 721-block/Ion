using Ion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
