using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using MapsterMapper;

namespace Ion.Application.Services;

internal class TripRecordService(IMapper mapper, 
    ITripRecordRepository repository,
    IUserRepository userRepository,
    IAnnouncementRepository announcementRepository)
    : ITripRecordService
{
    public async Task DeleteAsync(TripRecordViewModel model)
    {
        repository.Delete(mapper.Map<TripRecord>(model));
        await repository.SaveChangesAsync();
    }

    public IEnumerable<TripRecordViewModel> GetByUserId(int id)
    {
        return repository
            .GetByUserId(id)
            .Select(SetAnnouncementAndUser)
            .Select(mapper.Map<TripRecordViewModel>);
    }

    public IEnumerable<TripRecordViewModel> GetAll()
    {
        return repository
            .GetAll()
            .Select(SetAnnouncementAndUser)
            .Select(mapper.Map<TripRecordViewModel>);
    }

    public TripRecordViewModel GetById(int id)
    {
        return mapper.Map<TripRecordViewModel>(SetAnnouncementAndUser(repository.GetByID(id)));
    }

    private TripRecord SetAnnouncementAndUser(TripRecord tripRecord)
    {
        tripRecord.Announcement = announcementRepository.GetByID(tripRecord.AnnouncementId);
        tripRecord.User = userRepository.GetByID(tripRecord.UserId);
        return tripRecord;
    }
}