using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface IReviewsRepository : IBaseRepository<Reviews>
{
    Task<IEnumerable<Message>> GetByAnnouncementIdAsync(int id);
}
