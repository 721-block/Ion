using Ion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ion.Domain.Entities
{
    public class City(string name) : BaseEntity<int>
    {
        public string Name { get; set; } = string.IsNullOrWhiteSpace(name) ? string.Empty : name;

        public static implicit operator string(City city)
        {
            return city.Name;
        }
    }
}
