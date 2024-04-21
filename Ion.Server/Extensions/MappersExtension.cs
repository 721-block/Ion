using Ion.Application.IMappers;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using Ion.Server.Mappers;

namespace Ion.Server.Extensions;

public static class MappersExtension
{
    public static void AddMappers(this IServiceCollection collection)
    {
        collection.AddScoped<IBaseMapper<Announcement, AnnouncementViewModel>, AnnouncementMapper>();
        collection.AddScoped<IBaseMapper<Booking, BookingViewModel>, BookingMapper>();
        collection.AddScoped<IBaseMapper<Car, CarViewModel>, CarMapper>();
        collection.AddScoped<IBaseMapper<License, LicenseViewModel>, LicenseMapper>();
        collection.AddScoped<IBaseMapper<Message, MessageViewModel>, MessageMapper>();
        collection.AddScoped<IBaseMapper<Review, ReviewViewModel>, ReviewMapper>();
        collection.AddScoped<IBaseMapper<TripRecord, TripRecordViewModel>, TripRecordMapper>();
        collection.AddScoped<IBaseMapper<User, UserViewModel>, UserMapper>();
    }
}