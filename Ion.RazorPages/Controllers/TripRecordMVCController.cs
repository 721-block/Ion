using Ion.Server.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class TripRecordMVCController(TripRecordController controller) : Controller
    {
        private TripRecordController controller = controller;

        public IActionResult Index()
        {
            return View();
        }
    }
}
