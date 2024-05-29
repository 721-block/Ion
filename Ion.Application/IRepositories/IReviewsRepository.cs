using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface IReviewsRepository : IBaseRepository<Review>
{
    IEnumerable<Review> GetByAnnouncementId(int id);
    IEnumerable<Review> GetByUserId(int id);
}