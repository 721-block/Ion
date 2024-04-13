using Ion.Application.IRepositories;
using Ion.Domain.Entities;

namespace Ion.Infrastructure.Repositories;

public class CarRepository(CarRentContext context)
{
    private readonly CarRentContext context = context;

}