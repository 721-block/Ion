﻿using Ion.Application.IRepositories;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using MapsterMapper;

namespace Ion.Application.Services;

internal class BookingService(
    IMapper mapper,
    IBookingRepository bookingRepository,
    ITripRecordRepository tripRecordRepository,
    IAnnouncementRepository announcementRepository,
    IUserRepository userRepository) : IBookingService
{
    public async Task<BookingViewModel> AddAsync(BookingViewModel model)
    {
        var booking = await bookingRepository.AddAsync(mapper.Map<Booking>(model));
        await bookingRepository.SaveChangesAsync();
        return mapper.Map<BookingViewModel>(booking);
    }

    public async Task DeleteAsync(BookingViewModel model)
    {
        bookingRepository.Delete(mapper.Map<Booking>(model));
        await bookingRepository.SaveChangesAsync();
    }

    public async Task EndTripAsync(BookingViewModel model)
    {
        bookingRepository.Delete(mapper.Map<Booking>(model));
        var tripRecord = new TripRecord
        {
            AnnouncementId = model.Announcement!.Id,
            UserId = (int)model.ClientId!
        };
        await tripRecordRepository.AddAsync(tripRecord);
        await tripRecordRepository.SaveChangesAsync();
        await bookingRepository.SaveChangesAsync();
    }

    public IEnumerable<BookingViewModel> GetAll()
    {
        var allBookings = bookingRepository.GetAll().Select(SetUserAndAnnouncement).Select(mapper.Map<BookingViewModel>);
        
        return allBookings;
    }

    public IEnumerable<BookingViewModel> GetByAnnouncementId(int id)
    {
        return bookingRepository
            .GetByAnnouncementId(id)
            .Select(SetUserAndAnnouncement)
            .Select(mapper.Map<BookingViewModel>);
    }

    public IEnumerable<BookingViewModel> GetByAuthorId(int id)
    {
        return bookingRepository
            .GetByAuthorId(id)
            .Select(SetUserAndAnnouncement)
            .Select(mapper.Map<BookingViewModel>);
    }

    public IEnumerable<BookingViewModel> GetByClientId(int id)
    {
        return bookingRepository
            .GetByClientId(id)
            .Select(SetUserAndAnnouncement)
            .Select(mapper.Map<BookingViewModel>);
    }

    public BookingViewModel GetById(int id)
    {
        var booking = SetUserAndAnnouncement(bookingRepository.GetById(id));
        return mapper.Map<BookingViewModel>(booking);
    }

    public async Task UpdateAsync(BookingViewModel model)
    {
        var entity = bookingRepository.GetById(model.Id);
        var updatedEntity = mapper.Map(model, entity);

        bookingRepository.Update(updatedEntity);
        await bookingRepository.SaveChangesAsync();
    }

    private Booking SetUserAndAnnouncement(Booking booking)
    {
        booking.Announcement = announcementRepository.GetById(booking.AnnouncementId);
        booking.Client = userRepository.GetById(booking.ClientId);
        return booking;
    }
}