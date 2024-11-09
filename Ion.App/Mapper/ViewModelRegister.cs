using Ion.Application.ViewModels;
using Ion.Domain.Common;
using Ion.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ion.Application.Mapper;

public class ViewModelRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TripRecord, TripRecordViewModel>()
            .TwoWays()
            .Map(dest => dest.Description, src => src.Announcement.Description)
            .Map(dest => dest.AuthorFirstName, src => src.Announcement.Author.FirstName)
            .Map(dest => dest.AuthorLastName, src => src.Announcement.Author.LastName)
            .Map(dest => dest.CarName, src => src.Announcement.Car.Name)
            .Map(dest => dest.PricePerUnit, src => src.Announcement.PricePerUnit)
            .Map(dest => dest.PathToImages, src => src.Announcement.PathToImages);
    }
}
