using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using Mapster;

namespace Ion.Server.Extensions;

public static class MappersExtension
{
    private static readonly TypeAdapterConfig config = new();
    public static IServiceCollection RegisterMapster(this IServiceCollection services)
    {
        config.NewConfig<TripRecord, TripRecordViewModel>()
            .Map(dest => dest.Description, src => src.Announcement.Description)
            .Map(dest => dest.AuthorFirstName, src => src.Announcement.Author.FirstName)
            .Map(dest => dest.AuthorLastName, src => src.Announcement.Author.LastName)
            .Map(dest => dest.CarName, src => src.Announcement.Car.Name)
            .Map(dest => dest.PricePerUnit, src => src.Announcement.PricePerUnit)
            .Map(dest => dest.PathToImages, src => src.Announcement.PathToImages)
            .TwoWays();
        
        services.AddMapster();
        return services;
    }
}