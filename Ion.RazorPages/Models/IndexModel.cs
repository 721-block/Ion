using Ion.Application.Base;
using Ion.Server.RequestEntities;
using Ion.Server.RequestEntities.Announcement;

namespace Ion.RazorPages.Models
{
    public class IndexModel
    {
        public FilterParameters Parameters { get; set; } = new();
        public IEnumerable<AnnouncementToGet> Announcements { get; set; }
        public IEnumerable<string> Marks { get; set; }
    }
}
