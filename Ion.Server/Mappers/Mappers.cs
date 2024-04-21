using Ion.Application.ViewModels;
using Ion.Domain.Entities;
using Mapster;

namespace Ion.Server.Mappers;

public class AnnouncementMapper : BaseMapper<Announcement, AnnouncementViewModel>
{
}

public class BookingMapper : BaseMapper<Booking, BookingViewModel>
{
}

public class CarMapper : BaseMapper<Car, CarViewModel>
{
}

public class LicenseMapper : BaseMapper<License, LicenseViewModel>
{
}

public class MessageMapper : BaseMapper<Message, MessageViewModel>
{
}

public class ReviewMapper : BaseMapper<Review, ReviewViewModel>
{
}

public class TripRecordMapper : BaseMapper<TripRecord, TripRecordViewModel>
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

public class UserMapper : BaseMapper<User, UserViewModel>
{
}