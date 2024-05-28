using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.Review;
using Ion.Server.RequestEntities.User;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Models
{
    public class AnnounceModel
    {
        public UserToGet Author { get; set; }
        public IEnumerable<ReviewToGet> Reviews { get; set; }
        public AnnouncementToGet Annoncement { get; set; }
    }
}
