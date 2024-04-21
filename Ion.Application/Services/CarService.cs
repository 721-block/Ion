using Ion.Application.IMappers;
using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ion.Application.Services;

public class CarService(IBaseMapper<Car, CarViewModel> mapper, ICarRepository repository) : ICarService
{
    private readonly IBaseMapper<Car, CarViewModel> mapper = mapper;
    private readonly ICarRepository repository = repository;

    public void Add(CarViewModel model)
    {
        repository.Add(mapper.MapToEntity(model));
        repository.SaveChanges();
    }

    public void Delete(CarViewModel model)
    {
        repository.Delete(mapper.MapToEntity(model));
        repository.SaveChanges();
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
        repository.SaveChanges();
    }
}