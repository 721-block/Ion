using Ion.Application.IMappers;
using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;

namespace Ion.Application.Services;

internal class TripRecordService(IBaseMapper<TripRecord, TripRecordViewModel> mapper, ITripRecordRepository repository)
    : ITripRecordService
{
    public void Delete(TripRecordViewModel model)
    {
        repository.Delete(mapper.MapToEntity(model));
        repository.SaveChangesAsync();
    }

    public IEnumerable<TripRecordViewModel> GeByUserId(int id)
    {
        return repository.GetByUserId(id).Select(mapper.MapFromEntity);
    }

    public IEnumerable<TripRecordViewModel> GetAll()
    {
        return repository.GetAll().Select(mapper.MapFromEntity);
    }

    public TripRecordViewModel GetById(int id)
    {
        return mapper.MapFromEntity(repository.GetByID(id));
    }
}