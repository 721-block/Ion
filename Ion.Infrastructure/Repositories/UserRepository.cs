using Ion.Application.IRepositories;
using Ion.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ion.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(CarRentContext context) : base(context)
    {
        set = context.Users;
    }

    public User? GetByNamesAndEmail(string firstName, string lastName, string email)
    {
        return set.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName && u.Email == email);
    }
}