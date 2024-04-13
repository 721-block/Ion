using Ion.Application.ViewModels;
using Ion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ion.Application.IMappers
{
    public interface IBaseMapper<Entity, ViewModel> : IFromEntityMapper<Entity, ViewModel>, IToEntityMapper<Entity, ViewModel> 
        where Entity : BaseEntity 
        where ViewModel : BaseViewModel
    {
    }
}
