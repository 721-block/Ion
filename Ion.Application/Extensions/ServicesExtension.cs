using Ion.Application.Base.Hashers;
using Ion.Application.IServices;
using Ion.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ion.Application.Extensions;

public static class ServicesExtension
{
    public static void AddServices(this IServiceCollection collection, string userImagesPath)
    {
        collection.AddSingleton<IHasher, SHA256Hasher>();
        collection.AddScoped<IAnnouncementService, AnnouncementService>();
        collection.AddScoped<IBookingService, BookingService>();
        collection.AddScoped<ICarService, CarService>();
        collection.AddScoped<IMessageService, MessageService>();
        collection.AddScoped<IReviewService, ReviewService>();
        collection.AddScoped<ITripRecordService, TripRecordService>();
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IUserImageService>(x => new UserImageService(userImagesPath));
    }
}