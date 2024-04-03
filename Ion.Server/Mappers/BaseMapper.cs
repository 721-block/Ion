using Ion.Application.IMappers;
using Ion.Domain.Common;
using Ion.Server.ViewModels;
using Mapster;

namespace Ion.Server.Mappers;

public class BaseMapper<Entity, ViewModel> : IFromEntityMapper<Entity, ViewModel>, IToEntityMapper<Entity, ViewModel> 
    where Entity : BaseEntity 
    where ViewModel : BaseViewModel
{
    protected TypeAdapterConfig Config { get; init; } = new TypeAdapterConfig();

    public virtual ViewModel MapFromEntity(Entity entity)
    {
        return entity.Adapt<ViewModel>();
    }

    public void MapFromEntity(Entity entity, ViewModel model)
    {
        entity.Adapt(model);
    }

    public Entity MapToEntity(ViewModel model)
    {
        return model.Adapt<Entity>();
    }

    public void MapToEntity(ViewModel model, Entity entity)
    {
        model.Adapt(entity);
    }
}
