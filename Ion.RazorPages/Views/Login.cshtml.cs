using Ion.Server.RequestEntities.User;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ion.RazorPages.wwwroot.RazorPages;

public class Login : PageModel
{
    public UserToPost UserToPost { get; set; }
    
    public void OnPost()
    {
        
    }
}