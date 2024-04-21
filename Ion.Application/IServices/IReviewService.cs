﻿using Ion.Application.ViewModels;

namespace Ion.Application.IServices;

public interface IReviewService
{
    IEnumerable<ReviewViewModel> GetAll();
    ReviewViewModel GetById(int id);
    IEnumerable<ReviewViewModel> GetByAnnouncementId(int id);
    void Add(ReviewViewModel model);
    void Update(ReviewViewModel model);
    void Delete(ReviewViewModel model);
}