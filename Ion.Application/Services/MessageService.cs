using Ion.Application.IMappers;
using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;

namespace Ion.Application.Services;

public class MessageService(IBaseMapper<Message, MessageViewModel> mapper, IMessageRepository repository)
    : IMessageService
{
    private readonly IBaseMapper<Message, MessageViewModel> mapper = mapper;
    private readonly IMessageRepository repository = repository;

    public void Add(MessageViewModel model)
    {
        repository.Add(mapper.MapToEntity(model));
        repository.SaveChanges();
    }

    public void Delete(MessageViewModel model)
    {
        repository.Delete(mapper.MapToEntity(model));
        repository.SaveChanges();
    }

    public IEnumerable<MessageViewModel> GetAll()
    {
        return repository.GetAll().Select(mapper.MapFromEntity);
    }

    public IEnumerable<MessageViewModel> GetByAnnouncementId(int id)
    {
        return repository.GetByAnnouncementIdAsync(id).Select(mapper.MapFromEntity);
    }

    public MessageViewModel GetById(int id)
    {
        return mapper.MapFromEntity(repository.GetByID(id));
    }

    public void Update(MessageViewModel model)
    {
        repository.Update(mapper.MapToEntity(model));
        repository.SaveChanges();
    }
}