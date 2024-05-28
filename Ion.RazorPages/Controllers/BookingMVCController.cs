using Ion.Server.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class BookingMVCController(BookingController controller) : Controller
    {
        private BookingController controller = controller;

        public IActionResult Index()
        {
            return View();
        }
    }
}
