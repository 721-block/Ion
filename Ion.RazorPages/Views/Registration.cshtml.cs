using Ion.Server.RequestEntities.User;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ion.RazorPages.wwwroot.RazorPages;

public class Registration : PageModel
{
    public UserToPost UserToPost { get; set; }
    public string RepeatedPassword { get; set; }
    
    public void OnGet()
    {
        
    }
}