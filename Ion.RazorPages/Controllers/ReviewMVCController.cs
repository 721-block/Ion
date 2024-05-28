using Ion.Server.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class ReviewMVCController(ReviewController controller) : Controller
    {
        private ReviewController controller = controller;

        public IActionResult Index()
        {
            return View();
        }
    }
}
