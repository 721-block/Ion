using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface IMessageRepository : IBaseRepository<Message>
{
    Task<IEnumerable<Message>> GetByAnnouncementIdAsync(int id);
}
