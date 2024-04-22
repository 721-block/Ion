using Ion.Application.IMappers;
using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;

namespace Ion.Application.Services;

public class AnnouncementService(
    IBaseMapper<Announcement, AnnouncementViewModel> mapper,
    IAnnouncementRepository repository) : IAnnouncementService
{
    public async Task<AnnouncementViewModel> AddAsync(AnnouncementViewModel model)
    {
        var announcement = await repository.AddAsync(mapper.MapToEntity(model));
        await repository.SaveChangesAsync();
        return mapper.MapFromEntity(announcement);
    }

    public void Delete(AnnouncementViewModel model)
    {
        repository.Delete(mapper.MapToEntity(model));
        repository.SaveChangesAsync();
    }

    public IEnumerable<AnnouncementViewModel> GetAll()
    {
        return repository.GetAll().Select(mapper.MapFromEntity);
    }

    public IEnumerable<AnnouncementViewModel> GetByAuthorId(int id)
    {
        return repository.GetByAuthorId(id).Select(mapper.MapFromEntity);
    }

    public AnnouncementViewModel GetById(int id)
    {
        return mapper.MapFromEntity(repository.GetByID(id));
    }

    public void Update(AnnouncementViewModel model)
    {
        repository.Update(mapper.MapToEntity(model));
        repository.SaveChangesAsync();
    }
}