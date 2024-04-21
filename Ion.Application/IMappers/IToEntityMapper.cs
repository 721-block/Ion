using Ion.Domain.Common;

namespace Ion.Application.IMappers;

public interface IToEntityMapper<Entity, in Model> where Entity : BaseEntity
{
    Entity MapToEntity(Model model);

    void MapToEntity(Model model, Entity entity);
}