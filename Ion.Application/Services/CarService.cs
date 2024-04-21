using Ion.Application.IMappers;
using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;

namespace Ion.Application.Services;

public class CarService(IBaseMapper<Car, CarViewModel> mapper, ICarRepository repository) : ICarService
{
    public async void AddAsync(CarViewModel model)
    {
        await repository.AddAsync(mapper.MapToEntity(model));
        repository.SaveChangesAsync();
    }

    public void Delete(CarViewModel model)
    {
        repository.Delete(mapper.MapToEntity(model));
        repository.SaveChangesAsync();
    }

    public IEnumerable<CarViewModel> GetAll()
    {
        return repository.GetAll().Select(mapper.MapFromEntity);
    }

    public CarViewModel GetById(int id)
    {
        return mapper.MapFromEntity(repository.GetByID(id));
    }

    public IEnumerable<CarViewModel> GetByUserId(int id)
    {
        return repository.GetByUserId(id).Select(mapper.MapFromEntity);
    }

    public void Update(CarViewModel model)
    {
        repository.Update(mapper.MapToEntity(model));
        repository.SaveChangesAsync();
    }
}