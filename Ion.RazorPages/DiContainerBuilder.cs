using Ion.Infrastructure;
using Ion.Server.Extensions;
using Microsoft.EntityFrameworkCore;
using Ion.Application.Extensions;
using Ion.Infrastructure.Extensions;
using Ion.RazorPages.Extensions;

namespace Ion.RazorPages
{
    public class DiContainerBuilder
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

            var workingDirectory = Environment.CurrentDirectory + "\\wwwroot\\images";

            builder.Services.AddRepositories();
            builder.Services.RegisterMapster();
            builder.Services.AddServices(workingDirectory);
            builder.Services.AddApiControllers();

            builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
            builder.Services.AddRazorPages();
            builder.Services.AddEndpointsApiExplorer();


            return builder;
        }
    }
}
