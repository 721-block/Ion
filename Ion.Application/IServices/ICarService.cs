using Ion.Application.ViewModels;

namespace Ion.Application.IServices;

internal interface ICarService
{
    IEnumerable<CarViewModel> GetAll();
    CarViewModel GetById(int id);
    IEnumerable<CarViewModel> GetByUserId(int id);
    void Add(CarViewModel model);
    void Update(CarViewModel model);
    void Delete(CarViewModel model);
}