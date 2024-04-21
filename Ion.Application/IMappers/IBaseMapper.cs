using Ion.Application.ViewModels;
using Ion.Domain.Common;

namespace Ion.Application.IMappers;

public interface IBaseMapper<Entity, ViewModel> : IFromEntityMapper<Entity, ViewModel>,
    IToEntityMapper<Entity, ViewModel>
    where Entity : BaseEntity
    where ViewModel : BaseViewModel
{
}