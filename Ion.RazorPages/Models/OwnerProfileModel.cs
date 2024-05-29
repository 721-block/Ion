using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.Review;
using Ion.Server.RequestEntities.User;

namespace Ion.RazorPages.Models
{
    public class OwnerProfileModel
    {
        public float UserRating { get; set; }
        public IList<AnnouncementToGet> UserAnnouncements { get; set; }
        public UserToGet User { get; set; }
        public IList<ReviewToGet> UserReviews { get; set; }
    }
}
