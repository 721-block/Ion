using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using MapsterMapper;

namespace Ion.Application.Services;

internal class TripRecordService(IMapper mapper, 
    ITripRecordRepository repository,
    IUserRepository userRepository,
    IAnnouncementRepository announcementRepository,
    IReviewsRepository reviewsRepository)
    : ITripRecordService
{
    public async Task DeleteAsync(TripRecordViewModel model)
    {
        repository.Delete(mapper.Map<TripRecord>(model));
        await repository.SaveChangesAsync();
    }

    private TripRecordViewModel SetRating(TripRecordViewModel tripRecord)
    {
        var count = 0;
        var sum = 0f;
        var reviews = reviewsRepository.GetByAnnouncementId(tripRecord.AnnouncementId.Value);

        foreach (var review in reviews)
        {
            count++;
            sum += review.Rating;
        }

        tripRecord.ReviewsCount = count;
        tripRecord.Rating = count == 0 ? 0 : (float)Math.Round(sum / count, 1);

        return tripRecord;
    }

    public IEnumerable<TripRecordViewModel> GetByUserId(int id)
    {
        return repository
            .GetByUserId(id)
            .Select(SetAnnouncementAndUser)
            .Select(mapper.Map<TripRecordViewModel>)
            .Select(SetRating);
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
    public async Task DeleteAsync(TripRecordViewModel model)
    {
        repository.Delete(mapper.Map<TripRecord>(model));
        await repository.SaveChangesAsync();
    }

    private TripRecord SetAnnouncementAndUser(TripRecord tripRecord)
    {
        tripRecord.Announcement = announcementRepository.GetByID(tripRecord.AnnouncementId);
        tripRecord.User = userRepository.GetByID(tripRecord.UserId);
        return tripRecord;
    }

    private TripRecordViewModel SetRating(TripRecordViewModel tripRecord)
    {
        var count = 0;
        var sum = 0f;
        var reviews = reviewsRepository.GetByAnnouncementId(tripRecord.AnnouncementId.Value);

        foreach (var review in reviews)
        {
            count++;
            sum += review.Rating;
        }

        tripRecord.ReviewsCount = count;
        tripRecord.Rating = count == 0 ? 0 : (float)Math.Round(sum / count, 1);

        return tripRecord;
    }
}