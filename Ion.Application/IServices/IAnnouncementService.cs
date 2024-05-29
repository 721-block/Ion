using Ion.Application.Base;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;

namespace Ion.Application.IServices;

public interface IAnnouncementService
{
    IEnumerable<AnnouncementViewModel> GetAll();
    IEnumerable<AnnouncementViewModel> GetWithFilters(FilterParameters filterParameters);
    AnnouncementViewModel GetById(int id);
    IEnumerable<AnnouncementViewModel> GetByAuthorId(int id);
    Task<AnnouncementViewModel> AddAsync(AnnouncementViewModel model);
    Task UpdateAsync(AnnouncementViewModel model);
    Task DeleteAsync(AnnouncementViewModel model);
}