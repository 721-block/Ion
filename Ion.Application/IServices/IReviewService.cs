using Ion.Application.ViewModels;

namespace Ion.Application.IServices;

public interface IReviewService
{
    IEnumerable<ReviewViewModel> GetAll();
    ReviewViewModel GetById(int id);
    IEnumerable<ReviewViewModel> GetByAnnouncementId(int id);
    Task<ReviewViewModel> AddAsync(ReviewViewModel model);
    void Update(ReviewViewModel model);
    void Delete(ReviewViewModel model);
}