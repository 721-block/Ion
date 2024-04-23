using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface IUserRepository : IBaseRepository<User>
{
    User GetByNamesAndEmail(string firstName, string lastName, string email);
}