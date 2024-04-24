using Ion.Application.ViewModels;

namespace Ion.Application.IServices;

internal interface ITripRecordService
{
    IEnumerable<TripRecordViewModel> GetAll();
    TripRecordViewModel GetById(int id);
    IEnumerable<TripRecordViewModel> GeByUserId(int id);
    Task DeleteAsync(TripRecordViewModel model);
}