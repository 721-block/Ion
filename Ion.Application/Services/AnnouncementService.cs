using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using MapsterMapper;

namespace Ion.Application.Services;

public class AnnouncementService(
    IMapper mapper,
    IAnnouncementRepository repository) : IAnnouncementService
{
    public async Task<AnnouncementViewModel> AddAsync(AnnouncementViewModel model)
    {
        var announcement = await repository.AddAsync(mapper.Map<Announcement>(model));
        await repository.SaveChangesAsync();
        return mapper.Map<AnnouncementViewModel>(announcement);
    }

    public async Task DeleteAsync(AnnouncementViewModel model)
    {
        repository.Delete(mapper.Map<Announcement>(model));
        await repository.SaveChangesAsync();
    }

    public IEnumerable<AnnouncementViewModel> GetAll()
    {
        return repository.GetAll().Select(mapper.Map<AnnouncementViewModel>);
    }

    public IEnumerable<AnnouncementViewModel> GetByAuthorId(int id)
    {
        return repository.GetByAuthorId(id).Select(mapper.Map<AnnouncementViewModel>);
    }

    public AnnouncementViewModel GetById(int id)
    {
        return mapper.Map<AnnouncementViewModel>(repository.GetByID(id));
    }

    public async Task UpdateAsync(AnnouncementViewModel model)
    {
        var entity = repository.GetByID(model.Id);
        var updatedEntity = mapper.Map(model, entity);

        repository.Update(updatedEntity);
        await repository.SaveChangesAsync();
    }
}