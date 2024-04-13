using Ion.Application.IRepositories;
using Ion.Domain.Entities;

namespace Ion.Infrastructure.Repositories;

public class CarRepository : BaseRepository<Car>, ICarRepository
{
    public CarRepository(CarRentContext context) : base(context)
    {
        set = context.Cars;
    }

    public IEnumerable<Car> GetByUserId(int id)
    {
        return set.Where(c => c.UserId == id);
    }
}