using Ion.Application.ViewModels;

namespace Ion.Application.IServices;

public interface IReviewService
{
    IEnumerable<ReviewViewModel> GetAll();
    ReviewViewModel GetById(int id);
    IEnumerable<ReviewViewModel> GetByAnnouncementId(int id);
    Task<ReviewViewModel> AddAsync(ReviewViewModel model);
    Task UpdateAsync(ReviewViewModel model);
    Task DeleteAsync(ReviewViewModel model);
}