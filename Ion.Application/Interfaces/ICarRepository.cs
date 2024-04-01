using Ion.Domain.Entities;

namespace Ion.Application.Interfaces;

public interface ICarRepository : IBaseRepository<Car>
{
    Task<IEnumerable<Car>> GetByUserIdAsync(int id);
}
