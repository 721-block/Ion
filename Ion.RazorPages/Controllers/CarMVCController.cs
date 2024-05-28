using Ion.Server.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class CarMVCController(CarController controller) : Controller
    {
        private CarController controller = controller;

        public IActionResult Index()
        {
            return View();
        }
    }
}
