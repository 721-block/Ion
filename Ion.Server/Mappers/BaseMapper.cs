using Ion.Application.IMappers;
using Ion.Application.ViewModels;
using Ion.Domain.Common;
using Mapster;

namespace Ion.Server.Mappers;

public class BaseMapper<Entity, ViewModel> : IBaseMapper<Entity, ViewModel>
    where Entity : BaseEntity
    where ViewModel : BaseViewModel
{
    protected TypeAdapterConfig config { get; } = new();

    protected BaseMapper()
    {
        Configure()
            .TwoWays();
    }

    protected virtual TypeAdapterSetter<Entity, ViewModel> Configure()
    {
        return config.NewConfig<Entity, ViewModel>();
    }

    public virtual ViewModel MapFromEntity(Entity entity)
    {
        return entity.Adapt<ViewModel>();
    }

    public virtual void MapFromEntity(Entity entity, ViewModel model)
    {
        entity.Adapt(model);
    }

    public virtual Entity MapToEntity(ViewModel model)
    {
        return model.Adapt<Entity>();
    }

    public virtual void MapToEntity(ViewModel model, Entity entity)
    {
        model.Adapt(entity);
    }
}