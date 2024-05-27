using System.Collections;
using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.Review;
using Ion.Server.RequestEntities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ion.RazorPages.wwwroot.RazorPages;

public class OwnerProfile : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int UserId { get; set; }
    public float UserRating { get; set; }
   
    public IList<AnnouncementToGet> UserAnnouncements { get; set; }
    public UserToGet User { get; set; }
    public IList<ReviewToGet> UserReviews { get; set; }

    public void OnGet()
    {
        
    }

    public float GetAnnouncementRating(AnnouncementToGet announcementToGet)
    {
        throw new NotImplementedException();
    }

    public int GetReviewsCount(AnnouncementToGet announcementToGet)
    {
        throw new NotImplementedException();
    }
}