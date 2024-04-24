using Ion.Application.IMappers;
using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using MapsterMapper;

namespace Ion.Application.Services;

public class ReviewService(IMapper mapper, IReviewsRepository repository) : IReviewService
{
    public async Task<ReviewViewModel> AddAsync(ReviewViewModel model)
    {
        var review = await repository.AddAsync(mapper.Map<Review>(model));
        await repository.SaveChangesAsync();
        return mapper.Map<ReviewViewModel>(review);
    }

    public async Task DeleteAsync(ReviewViewModel model)
    {
        repository.Delete(mapper.Map<Review>(model));
        await repository.SaveChangesAsync();
    }

    public IEnumerable<ReviewViewModel> GetAll()
    {
        return repository.GetAll().Select(mapper.Map<ReviewViewModel>);
    }

    public IEnumerable<ReviewViewModel> GetByAnnouncementId(int id)
    {
        return repository.GetByAnnouncementId(id).Select(mapper.Map<ReviewViewModel>);
    }

    public ReviewViewModel GetById(int id)
    {
        return mapper.Map<ReviewViewModel>(repository.GetByID(id));
    }

    public async Task UpdateAsync(ReviewViewModel model)
    {
        repository.Update(mapper.Map<Review>(model));
        await repository.SaveChangesAsync();
    }
}