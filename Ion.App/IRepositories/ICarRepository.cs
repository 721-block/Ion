using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface ICarRepository : IBaseRepository<Car>
{
    IEnumerable<Car> GetByUserId(int id);
}