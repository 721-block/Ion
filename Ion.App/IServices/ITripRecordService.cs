using Ion.Application.ViewModels;

namespace Ion.Application.IServices;

public interface ITripRecordService
{
    IEnumerable<TripRecordViewModel> GetAll();
    TripRecordViewModel GetById(int id);
    IEnumerable<TripRecordViewModel> GetByUserId(int id);
    Task DeleteAsync(TripRecordViewModel model);
}