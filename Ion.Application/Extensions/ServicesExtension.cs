using Ion.Application.IServices;
using Ion.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Ion.Application.Extensions;

public static class ServicesExtension
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddScoped<IAnnouncementService, AnnouncementService>();
        collection.AddScoped<IBookingService, BookingService>();
        collection.AddScoped<ICarService, CarService>();
        collection.AddScoped<IMessageService, MessageService>();
        collection.AddScoped<IReviewService, ReviewService>();
        collection.AddScoped<ITripRecordService, TripRecordService>();
        collection.AddScoped<IUserService, UserService>();
    }
}