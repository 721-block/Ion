using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface IAnnouncementRepository : IBaseRepository<Announcement>
{
    Task<IEnumerable<Announcement>> GetByAuthorIdAsync(int id);
}