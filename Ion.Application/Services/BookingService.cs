﻿using Ion.Application.IMappers;
using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;

namespace Ion.Application.Services;

internal class BookingService(
    IBaseMapper<Booking, BookingViewModel> mapper,
    IBookingRepository bookingRepository,
    ITripRecordRepository tripRecordRepository) : IBookingService
{
    public async Task<BookingViewModel> AddAsync(BookingViewModel model)
    {
        var booking = await bookingRepository.AddAsync(mapper.MapToEntity(model));
        await bookingRepository.SaveChangesAsync();
        return mapper.MapFromEntity(booking);
    }

    public void Delete(BookingViewModel model)
    {
        bookingRepository.Delete(mapper.MapToEntity(model));
        bookingRepository.SaveChangesAsync();
    }

    public void EndTrip(BookingViewModel model)
    {
        bookingRepository.Delete(mapper.MapToEntity(model));
        var tripRecord = new TripRecord
        {
            AnnouncementId = model.Announcement.Id,
            UserId = model.ClientId
        };
        tripRecordRepository.AddAsync(tripRecord);
        tripRecordRepository.SaveChangesAsync();
        bookingRepository.SaveChangesAsync();
    }

    public IEnumerable<BookingViewModel> GetAll()
    {
        return bookingRepository.GetAll().Select(mapper.MapFromEntity);
    }

    public IEnumerable<BookingViewModel> GetByAnnouncementId(int id)
    {
        return bookingRepository.GetByAnnouncementId(id).Select(mapper.MapFromEntity);
    }

    public IEnumerable<BookingViewModel> GetByAuthorId(int id)
    {
        return bookingRepository.GetByAuthorId(id).Select(mapper.MapFromEntity);
    }

    public IEnumerable<BookingViewModel> GetByClientId(int id)
    {
        return bookingRepository.GetByClientId(id).Select(mapper.MapFromEntity);
    }

    public BookingViewModel GetById(int id)
    {
        return mapper.MapFromEntity(bookingRepository.GetByID(id));
    }

    public void Update(BookingViewModel model)
    {
        bookingRepository.Update(mapper.MapToEntity(model));
        bookingRepository.SaveChangesAsync();
    }
}