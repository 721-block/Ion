﻿using Ion.Application.Base;
using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using MapsterMapper;

namespace Ion.Application.Services;

public class AnnouncementService(
    IMapper mapper,
    IAnnouncementRepository repository,
    IUserRepository userRepository,
    ICarRepository carRepository,
    IReviewsRepository reviewsRepository) : IAnnouncementService
{
    public async Task<AnnouncementViewModel> AddAsync(AnnouncementViewModel model)
    {

        var announcement = await repository.AddAsync(mapper.Map<Announcement>(model));
        await repository.SaveChangesAsync();
        return mapper.Map<AnnouncementViewModel>(announcement);
    }

    public async Task DeleteAsync(AnnouncementViewModel model)
    {
        repository.Delete(mapper.Map<Announcement>(model));
        await repository.SaveChangesAsync();
    }

    public IEnumerable<AnnouncementViewModel> GetAll()
    {
        return repository.GetAll().Select(SetUserAndCar).Select(mapper.Map<AnnouncementViewModel>).Select(SetRating);
    }

    public IEnumerable<AnnouncementViewModel> GetWithFilters(FilterParameters filterParameters)
    {
        var announcements = GetAll();
        return announcements
            .Where(a =>
                (a.CarName == filterParameters.CarName || filterParameters.CarName is null)
                && (filterParameters.Price >= a.PricePerUnit || filterParameters.Price is null)
                && (filterParameters.BodyType == a.CarBodyType || filterParameters.BodyType is null)
                && (filterParameters.GearboxType == a.CarGearboxType || filterParameters.GearboxType is null));
    }

    public IEnumerable<AnnouncementViewModel> GetByAuthorId(int id)
    {
        var announcements = repository.GetByAuthorId(id);
        announcements = announcements.Select(SetUserAndCar);
        return announcements.Select(mapper.Map<AnnouncementViewModel>).Select(SetRating);
    }

    public AnnouncementViewModel GetById(int id)
    {
        var entity = repository.GetById(id);
        entity = SetUserAndCar(entity);
        var viewModel = mapper.Map<AnnouncementViewModel>(entity);
        SetRating(viewModel);
        return viewModel;
    }

    public async Task UpdateAsync(AnnouncementViewModel model)
    {
        var entity = repository.GetById(model.Id);
        var updatedEntity = mapper.Map(model, entity);

        repository.Update(updatedEntity);
        await repository.SaveChangesAsync();
    }

    private Announcement SetUserAndCar(Announcement announcement)
    {
        announcement.Author = userRepository.GetById(announcement.AuthorId);
        announcement.Car = carRepository.GetById(announcement.CarId);
        return announcement;
    }

    private AnnouncementViewModel SetRating(AnnouncementViewModel announcement)
    {
        var count = 0;
        var sum = 0f;
        var reviews = reviewsRepository.GetByAnnouncementId(announcement.Id);

        foreach (var review in reviews)
        {
            count++;
            sum += review.Rating;
        }

        announcement.ReviewsCount = count;
        announcement.Rating = count == 0 ? 0 : (float)Math.Round(sum / count, 1);

        return announcement;
    }
}