using Ion.Domain.Entities;

namespace Ion.Application.Common.Interfaces
{
    public interface IAnnouncementRepository : IRepository<Announcement, int>, IReadRepository<Announcement, int>
    {
    }
}
