using Ion.Server.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class AnnouncementMVCController(AnnouncementController controller) : Controller
    {
        private AnnouncementController controller = controller;

        public IActionResult Index()
        {
            return View();
        }
    }
}
