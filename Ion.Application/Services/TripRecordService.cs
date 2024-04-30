using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using MapsterMapper;

namespace Ion.Application.Services;

internal class TripRecordService(IMapper mapper, ITripRecordRepository repository)
    : ITripRecordService
{
    public async Task DeleteAsync(TripRecordViewModel model)
    {
        repository.Delete(mapper.Map<TripRecord>(model));
        await repository.SaveChangesAsync();
    }

    public IEnumerable<TripRecordViewModel> GetByUserId(int id)
    {
        return repository.GetByUserId(id).Select(mapper.Map<TripRecordViewModel>);
    }

    public IEnumerable<TripRecordViewModel> GetAll()
    {
        return repository.GetAll().Select(mapper.Map<TripRecordViewModel>);
    }

    public TripRecordViewModel GetById(int id)
    {
        return mapper.Map<TripRecordViewModel>(repository.GetByID(id));
    }
}