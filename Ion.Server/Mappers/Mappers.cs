using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using Mapster;

namespace Ion.Server.Mappers;

public partial class AnnouncementMapper : BaseMapper<Announcement, AnnouncementViewModel>
{
}

public partial class BookingMapper : BaseMapper<Booking, BookingViewModel>
{
}

public partial class CarMapper : BaseMapper<Car, CarViewModel>
{
}

public partial class LicenseMapper : BaseMapper<License, LicenseViewModel>
{
}

public partial class MessageMapper : BaseMapper<Message, MessageViewModel>
{
}

public partial class ReviewMapper : BaseMapper<Review, ReviewViewModel>
{
}

public partial class TripRecordMapper : BaseMapper<TripRecord, TripRecordViewModel>
{
    protected override TypeAdapterSetter<TripRecord, TripRecordViewModel> Configure()
    {
        return base.Configure()
            .Map(dest => dest.Description, src => src.Announcement.Description)
            .Map(dest => dest.AuthorFirstName, src => src.Announcement.Author.FirstName)
            .Map(dest => dest.AuthorLastName, src => src.Announcement.Author.LastName)
            .Map(dest => dest.CarName, src => src.Announcement.Car.Name)
            .Map(dest => dest.PricePerUnit, src => src.Announcement.PricePerUnit)
            .Map(dest => dest.PathToImages, src => src.Announcement.PathToImages);
    }
}

public partial class UserMapper : BaseMapper<User, UserViewModel>
{
}