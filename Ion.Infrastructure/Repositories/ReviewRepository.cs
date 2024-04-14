using Ion.Application.IRepositories;
using Ion.Domain.Entities;

namespace Ion.Infrastructure.Repositories;

public class ReviewRepository : BaseRepository<Review>, IReviewsRepository
{
    public ReviewRepository(CarRentContext context) : base(context)
    {
        set = context.Reviews;
    }

    public IEnumerable<Review> GetByAnnouncementId(int id)
    {
        return set.Where(r => r.AnnouncementId == id);
    }
}