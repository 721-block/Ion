using Ion.Application.ViewModels;

namespace Ion.Application.IServices;

public interface IMessageService
{
    IEnumerable<MessageViewModel> GetAll();
    MessageViewModel GetById(int id);
    IEnumerable<MessageViewModel> GetByAnnouncementId(int id);
    Task<MessageViewModel> AddAsync(MessageViewModel model);
    Task UpdateAsync(MessageViewModel model);
    Task DeleteAsync(MessageViewModel model);
}