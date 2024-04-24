using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using MapsterMapper;

namespace Ion.Application.Services;

public class CarService(IMapper mapper, ICarRepository repository) : ICarService
{
    public async Task<CarViewModel> AddAsync(CarViewModel model)
    {
        var car = await repository.AddAsync(mapper.Map<Car>(model));
        await repository.SaveChangesAsync();
        return mapper.Map<CarViewModel>(car);
    }

    public async Task DeleteAsync(CarViewModel model)
    {
        repository.Delete(mapper.Map<Car>(model));
        await repository.SaveChangesAsync();
    }

    public IEnumerable<CarViewModel> GetAll()
    {
        return repository.GetAll().Select(mapper.Map<CarViewModel>);
    }

    public CarViewModel GetById(int id)
    {
        return mapper.Map<CarViewModel>(repository.GetByID(id));
    }

    public IEnumerable<CarViewModel> GetByUserId(int id)
    {
        return repository.GetByUserId(id).Select(mapper.Map<CarViewModel>);
    }

    public async Task UpdateAsync(CarViewModel model)
    {
        repository.Update(mapper.Map<Car>(model));
        await repository.SaveChangesAsync();
    }
}