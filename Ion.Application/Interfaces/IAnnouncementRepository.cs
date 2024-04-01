using Ion.Domain.Entities;

namespace Ion.Application.Interfaces;

public interface IAnnouncementRepository : IBaseRepository<Announcement>
{
    Task<IEnumerable<Announcement>> GetByAuthorIdAsync(int id);
}