using Ion.Domain.Common;

namespace Ion.Application.IMappers;

public interface IFromEntityMapper<in Entity, Model> where Entity : BaseEntity
{
    Model MapFromEntity(Entity entity);

    void MapFromEntity(Entity entity, Model model);
}
