using Ion.Application.IRepositories;
using Ion.Domain.Entities;

namespace Ion.Infrastructure.Repositories;

public class BookingRepository : BaseRepository<Booking>, IBookingRepository
{
    public BookingRepository(CarRentContext context) : base(context)
    {
        set = context.Bookings;
    }

    public IEnumerable<Booking> GetByAnnouncementId(int id)
    {
        return set.Where(b => b.AnnouncementId == id);
    }

    public IEnumerable<Booking> GetByClientId(int id)
    {
        return set.Where(b => b.ClientId == id);
    }

    public IEnumerable<Booking> GetByAuthorId(int id)
    {
        return set.Where(b => b.Announcement.AuthorId == id);
    }
}