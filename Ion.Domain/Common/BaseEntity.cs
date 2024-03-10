using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ion.Domain.Common
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Key { get; set; }
    }
}
