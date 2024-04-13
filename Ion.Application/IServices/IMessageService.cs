using Ion.Application.ViewModels;

namespace Ion.Application.IServices;

internal interface IMessageService
{
    IEnumerable<MessageViewModel> GetAll();
    MessageViewModel GetById(int id);
    IEnumerable<MessageViewModel> GetByAnnouncementIdAsync(int id);
    void Add(MessageViewModel model);
    void Update(MessageViewModel model);
    void Delete(int id);
}
