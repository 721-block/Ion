using Ion.Application.ViewModels;

namespace Ion.Application.IServices;

public interface IAnnouncementService
{
    IEnumerable<AnnouncementViewModel> GetAll();
    AnnouncementViewModel GetById(int id);
    IEnumerable<AnnouncementViewModel> GetByAuthorId(int id);
    void Add(AnnouncementViewModel model);
    void Update(AnnouncementViewModel model);
    void Delete(AnnouncementViewModel model);
}
