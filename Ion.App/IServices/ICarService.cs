using Ion.Application.ViewModels;

namespace Ion.Application.IServices;

public interface ICarService
{
    IEnumerable<CarViewModel> GetAll();
    CarViewModel GetById(int id);
    IEnumerable<CarViewModel> GetByUserId(int id);
    Task<CarViewModel> AddAsync(CarViewModel model);
    Task UpdateAsync(CarViewModel model);
    Task DeleteAsync(CarViewModel model);
}