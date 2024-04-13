using Ion.Application.IRepositories;
using Ion.Domain.Entities;

namespace Ion.Infrastructure.Repositories;

public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    public MessageRepository(CarRentContext context) : base(context)
    {
        set = context.Messages;
    }

    public IEnumerable<Message> GetByAnnouncementIdAsync(int id)
    {
        return set.Where(m => m.AnnouncementId == id);
    }
}