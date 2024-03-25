using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ion.Application.Interfaces
{
    public interface IMapper<Source, Destination>
    {
        Destination Map(Source source);

        Destination Map(Source source, Destination destination);
    }
}
