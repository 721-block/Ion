using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class UserMVCController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
