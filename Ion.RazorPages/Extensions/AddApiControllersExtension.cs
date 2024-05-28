using Ion.Server.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Extensions
{
    public static class AddApiControllersExtension
    {
        public static IServiceCollection AddApiControllers(this IServiceCollection services)
        {
            services.AddScoped<AnnouncementController>();
            services.AddScoped<BookingController>();
            services.AddScoped<CarController>();
            services.AddScoped<MessageController>();
            services.AddScoped<ReviewController>();
            services.AddScoped<TripRecordController>();
            services.AddScoped<UserController>();

            return services;
        }
    }
}
