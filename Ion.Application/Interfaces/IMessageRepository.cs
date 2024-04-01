using Ion.Domain.Entities;

namespace Ion.Application.Interfaces;

public interface IMessageRepository : IBaseRepository<Message>
{
    Task<IEnumerable<Message>> GetByAnnouncementIdAsync(int id);
}
