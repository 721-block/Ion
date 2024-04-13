using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface IAnnouncementRepository : IBaseRepository<Announcement>
{
    IEnumerable<Announcement> GetByAuthorId(int id);
}