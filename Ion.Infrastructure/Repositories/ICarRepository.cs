using Ion.Application.IRepositories;
using Ion.Domain.Entities;

namespace Ion.Infrastructure.Repositories;

public class CarRepository(CarRentContext context) : ICarRepository
{
    private readonly CarRentContext context = context;

    public Task<Car> AddAsync(Car entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Car>> AddRangeAsync(IEnumerable<Car> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Car entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateRangeAsync(IEnumerable<Car> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Car entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRangeAsync(IEnumerable<Car> entities, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Car> GetAll()
    {
        throw new NotImplementedException();
    }

    public Car GetByID(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Car>> GetByUserIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}