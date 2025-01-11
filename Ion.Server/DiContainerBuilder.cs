using Ion.Application.Extensions;
using Ion.Infrastructure;
using Ion.Infrastructure.Extensions;
using Ion.Server.Extensions;
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
            options
                .UseSqlServer(connectionString);
        });

        var workingDirectory = Environment.CurrentDirectory + "\\images";

        builder.Services.AddRepositories();
        builder.Services.RegisterMapster();
        builder.Services.AddServices(workingDirectory);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }
}