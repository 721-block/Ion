﻿using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface IMessageRepository : IBaseRepository<Message>
{
    IEnumerable<Message> GetByAnnouncementId(int id);
}