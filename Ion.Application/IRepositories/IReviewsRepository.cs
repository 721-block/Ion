﻿using Ion.Domain.Entities;

namespace Ion.Application.IRepositories;

public interface IReviewsRepository : IBaseRepository<Review>
{
    IEnumerable<Message> GetByAnnouncementId(int id);
}