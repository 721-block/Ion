﻿using Ion.Domain.Entities;

namespace Ion.Application.Interfaces;

public interface IReviewsRepository : IBaseRepository<Reviews>
{
    Task<IEnumerable<Message>> GetByAnnouncementIdAsync(int id);
}
