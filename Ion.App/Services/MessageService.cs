using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using MapsterMapper;

namespace Ion.Application.Services;

public class MessageService(IMapper mapper, 
    IMessageRepository repository,
    IUserRepository userRepository)
    : IMessageService
{
    public async Task<MessageViewModel> AddAsync(MessageViewModel model)
    {
        var message = await repository.AddAsync(mapper.Map<Message>(model));
        await repository.SaveChangesAsync();
        return mapper.Map<MessageViewModel>(message);
    }

    public async Task DeleteAsync(MessageViewModel model)
    {
        repository.Delete(mapper.Map<Message>(model));
        await repository.SaveChangesAsync();
    }

    public IEnumerable<MessageViewModel> GetAll()
    {
        return repository
            .GetAll()
            .Select(SetUsers)
            .Select(mapper.Map<MessageViewModel>);
    }

    public IEnumerable<MessageViewModel> GetByAnnouncementId(int id)
    {
        return repository
            .GetByAnnouncementId(id)
            .Select(SetUsers)
            .Select(mapper.Map<MessageViewModel>);
    }

    public MessageViewModel GetById(int id)
    {
        return mapper.Map<MessageViewModel>(SetUsers(repository.GetByID(id)));
    }

    public async Task UpdateAsync(MessageViewModel model)
    {
        var entity = repository.GetByID(model.Id);
        var updatedEntity = mapper.Map(model, entity);

        repository.Update(updatedEntity);
        await repository.SaveChangesAsync();
    }

    private Message SetUsers(Message message)
    {
        message.Sender = userRepository.GetByID(message.SenderId);
        message.Reciever = userRepository.GetByID(message.ReceiverId);
        return message;
    }
}