using Ion.Domain.Entities;

namespace Ion.Application.Interfaces;

public interface IBookingRepository : IBaseRepository<Booking>
{
    Task<IEnumerable<Booking>> GetByAnnouncementIdAsync(int id);
    Task<IEnumerable<Booking>> GetByClientIdAsync(int id);
    Task<IEnumerable<Booking>> GetByAuthorIdAsync(int id);
}

