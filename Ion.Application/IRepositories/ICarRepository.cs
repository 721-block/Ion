using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface ICarRepository : IBaseRepository<Car>
{
    Task<IEnumerable<Car>> GetByUserIdAsync(int id);
}
