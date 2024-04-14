using Ion.Application.IRepositories;
using Ion.Infrastructure;
using Ion.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ion.Server;

public static class DiContainerBuilder
{
    public static WebApplicationBuilder BuildContainer(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("Ion");
        builder.Services.AddDbContext<CarRentContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        builder.Services.AddScoped<IBookingRepository, BookingRepository>();
        builder.Services.AddScoped<ICarRepository, CarRepository>();
        builder.Services.AddScoped<ILicenseRepository, LicenseRepository>();
        builder.Services.AddScoped<IMessageRepository, MessageRepository>();
        builder.Services.AddScoped<IReviewsRepository, ReviewRepository>();
        builder.Services.AddScoped<ITripRecordRepository, TripRecordRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        
        return builder;
    }
}