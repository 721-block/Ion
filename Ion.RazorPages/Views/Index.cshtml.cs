using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.Review;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ion.RazorPages.wwwroot.RazorPages;

public class Index : PageModel
{
    public IList<AnnouncementToGet> Annoncements { get; set; }
    public void OnGet()
    {
        
    }

    public float GetAnnouncementRating(AnnouncementToGet announcement)
    {
        throw new NotImplementedException();
    }

    public int GetReviewsCount(AnnouncementToGet announcementToGet)
    {
        throw new NotImplementedException();
    }
}