using Ion.Server.RequestEntities.TripRecord;
using Ion.Server.RequestEntities.User;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ion.RazorPages.wwwroot.RazorPages;

public class UserProfile : PageModel
{
    public UserToGet UserToGet { get; set; }
    public IList<TripRecordToGet> TripRecords { get; set; }
    
    public void OnGet()
    {
        
    }

    public float GetAnnouncementRating(int announcementId)
    {
        throw new NotImplementedException();
    }

    public float GetReviewsCount(int announcementId)
    {
        throw new NotImplementedException();
    }
}