using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.Review;
using Ion.Server.RequestEntities.User;

namespace Ion.RazorPages.Models
{
    public class OwnerProfileModel
    {
        public float UserRating { get; set; }
        public float UserReviewsCount { get; set; }
        public IEnumerable<AnnouncementToGet> UserAnnouncements { get; set; }
        public IEnumerable<ReviewToGet> Reviews { get; set; }
        public UserToGet User { get; set; }

    }
}
