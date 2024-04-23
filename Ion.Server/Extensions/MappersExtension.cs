using Ion.Application.IMappers;
using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using Ion.Server.Mappers;

namespace Ion.Server.Extensions;

public static class MappersExtension
{
    public static IServiceCollection AddMappers(this IServiceCollection collection)
    {
        return collection
            .AddScoped<IBaseMapper<Announcement, AnnouncementViewModel>, AnnouncementMapper>()
            .AddScoped<IBaseMapper<Booking, BookingViewModel>, BookingMapper>()
            .AddScoped<IBaseMapper<Car, CarViewModel>, CarMapper>()
            .AddScoped<IBaseMapper<License, LicenseViewModel>, LicenseMapper>()
            .AddScoped<IBaseMapper<Message, MessageViewModel>, MessageMapper>()
            .AddScoped<IBaseMapper<Review, ReviewViewModel>, ReviewMapper>()
            .AddScoped<IBaseMapper<TripRecord, TripRecordViewModel>, TripRecordMapper>()
            .AddScoped<IBaseMapper<User, UserViewModel>, UserMapper>();
    }
}