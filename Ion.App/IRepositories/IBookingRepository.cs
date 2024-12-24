using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface IBookingRepository : IBaseRepository<Booking>
{
    IEnumerable<Booking> GetByAnnouncementId(int id);
    IEnumerable<Booking> GetByClientId(int id);
    IEnumerable<Booking> GetByAuthorId(int id);
}