using Ion.Application.ViewModels;
using Ion.Domain.Entities;

namespace Ion.Application.IServices;

public interface IAnnouncementService
{
    IEnumerable<AnnouncementViewModel> GetAll();
    AnnouncementViewModel GetById(int id);
    IEnumerable<AnnouncementViewModel> GetByAuthorId(int id);
    Task<AnnouncementViewModel> AddAsync(AnnouncementViewModel model);
    void Update(AnnouncementViewModel model);
    void Delete(AnnouncementViewModel model);
}