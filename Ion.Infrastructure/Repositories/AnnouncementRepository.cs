using Ion.Application.IRepositories;
using Ion.Domain.Entities;

namespace Ion.Infrastructure.Repositories;

public class AnnouncementRepository : BaseRepository<Announcement>, IAnnouncementRepository
{
    public AnnouncementRepository(CarRentContext context) : base(context)
    {
        set = context.Announcements;
    }

    public IEnumerable<Announcement> GetByAuthorId(int id)
    {
        return set.Where(a => a.AuthorId == id);
    }
}