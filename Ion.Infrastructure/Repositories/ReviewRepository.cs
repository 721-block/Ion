using Ion.Application.IRepositories;
using Ion.Domain.Entities;

namespace Ion.Infrastructure.Repositories;

public class ReviewRepository : BaseRepository<Review>, IReviewsRepository
{
    public ReviewRepository(CarRentContext context) : base(context)
    {
        set = context.Reviews;
    }

    public IEnumerable<Message> GetByAnnouncementId(int id)
    {
        return context.Messages.Where(m => m.AnnouncementId == id);
    }
}