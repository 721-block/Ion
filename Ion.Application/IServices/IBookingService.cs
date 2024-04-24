using Ion.Application.ViewModels;

namespace Ion.Application.IServices;

public interface IBookingService
{
    IEnumerable<BookingViewModel> GetAll();
    BookingViewModel GetById(int id);
    IEnumerable<BookingViewModel> GetByAnnouncementId(int id);
    IEnumerable<BookingViewModel> GetByClientId(int id);
    IEnumerable<BookingViewModel> GetByAuthorId(int id);
    Task<BookingViewModel> AddAsync(BookingViewModel model);
    Task UpdateAsync(BookingViewModel model);
    Task DeleteAsync(BookingViewModel model);
    Task EndTripAsync(BookingViewModel model);
}