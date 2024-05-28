using Ion.Server.RequestEntities.Announcement;

namespace Ion.RazorPages.Models
{
    public class IndexModel
    {
        public IEnumerable<AnnouncementToGet> Announcements { get; set; }

        public IEnumerable<string> Marks { get; set; }
    }
}
