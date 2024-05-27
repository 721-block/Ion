using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.Review;
using Ion.Server.RequestEntities.User;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ion.RazorPages.Views;

public class Announce : PageModel
{
    public UserToGet Author { get; set; }
    public List<ReviewToGet> Reviews { get; set; }
    public int AnnouncementId { get; set; }
    public AnnouncementToGet Annoncement { get; set; }
    
    public void OnGet()
    {
        
    }

    public void OnPost()
    {
        
    }
}