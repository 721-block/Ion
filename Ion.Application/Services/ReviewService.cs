using Ion.Application.IMappers;
using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;

namespace Ion.Application.Services;

public class ReviewService(IBaseMapper<Review, ReviewViewModel> mapper, IReviewsRepository repository) : IReviewService
{
    private readonly IBaseMapper<Review, ReviewViewModel> mapper = mapper;
    private readonly IReviewsRepository repository = repository;

    public void Add(ReviewViewModel model)
    {
        repository.Add(mapper.MapToEntity(model));
        repository.SaveChanges();
    }

    public void Delete(ReviewViewModel model)
    {
        repository.Delete(mapper.MapToEntity(model));
        repository.SaveChanges();
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
        repository.SaveChanges();
    }
}
