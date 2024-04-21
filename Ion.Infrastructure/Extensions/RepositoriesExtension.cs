using Ion.Application.IRepositories;
using Ion.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ion.Infrastructure.Extensions;

public static class RepositoriesExtension
{
    public static void AddRepositories(this IServiceCollection collection)
    {
        collection.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        collection.AddScoped<IBookingRepository, BookingRepository>();
        collection.AddScoped<ICarRepository, CarRepository>();
        collection.AddScoped<ILicenseRepository, LicenseRepository>();
        collection.AddScoped<IMessageRepository, MessageRepository>();
        collection.AddScoped<IReviewsRepository, ReviewRepository>();
        collection.AddScoped<ITripRecordRepository, TripRecordRepository>();
        collection.AddScoped<IUserRepository, UserRepository>();
    }
}