using Ion.Application.ViewModels;
using Ion.Domain.Entities;

namespace Ion.Application.IServices;

public interface IBookingService
{
    IEnumerable<BookingViewModel> GetAll();
    BookingViewModel GetById(int id);
    IEnumerable<BookingViewModel> GetByAnnouncementId(int id);
    IEnumerable<BookingViewModel> GetByClientId(int id);
    IEnumerable<BookingViewModel> GetByAuthorId(int id);
    void Add(BookingViewModel model);
    void Update(BookingViewModel model);
    void Delete(BookingViewModel model);
    void EndTrip(BookingViewModel model);
}
