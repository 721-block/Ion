using Ion.Application.ViewModels;
using Ion.Domain.Entities;

namespace Ion.Application.IServices;

internal interface ICarService
{
    IEnumerable<CarViewModel> GetAll();
    CarViewModel GetById(int id);
    IEnumerable<CarViewModel> GetByUserId(int id);
    void Add(CarViewModel model);
    void Update(CarViewModel model);
    void Delete(int id);
}
