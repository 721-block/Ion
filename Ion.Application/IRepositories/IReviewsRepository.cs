using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface IReviewsRepository : IBaseRepository<Review>
{
    Task<IEnumerable<Message>> GetByAnnouncementIdAsync(int id);
}
