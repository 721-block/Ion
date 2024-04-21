using Ion.Application.ViewModels;

namespace Ion.Application.IServices;

internal interface IMessageService
{
    IEnumerable<MessageViewModel> GetAll();
    MessageViewModel GetById(int id);
    IEnumerable<MessageViewModel> GetByAnnouncementId(int id);
    void AddAsync(MessageViewModel model);
    void Update(MessageViewModel model);
    void Delete(MessageViewModel model);
}