using Ion.Application.IMappers;
using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;

namespace Ion.Application.Services;

public class ReviewService(IBaseMapper<Review, ReviewViewModel> mapper, IReviewsRepository repository) : IReviewService
{
    public async Task<ReviewViewModel> AddAsync(ReviewViewModel model)
    {
        var review = await repository.AddAsync(mapper.MapToEntity(model));
        await repository.SaveChangesAsync();
        return mapper.MapFromEntity(review);
    }

    public void Delete(ReviewViewModel model)
    {
        repository.Delete(mapper.MapToEntity(model));
        repository.SaveChangesAsync();
    }

    public IEnumerable<ReviewViewModel> GetAll()
    {
        return repository.GetAll().Select(mapper.MapFromEntity);
    }

    public IEnumerable<ReviewViewModel> GetByAnnouncementId(int id)
    {
        return repository.GetByAnnouncementId(id).Select(mapper.MapFromEntity);
    }

    public ReviewViewModel GetById(int id)
    {
        return mapper.MapFromEntity(repository.GetByID(id));
    }

    public void Update(ReviewViewModel model)
    {
        repository.Update(mapper.MapToEntity(model));
        repository.SaveChangesAsync();
    }
}