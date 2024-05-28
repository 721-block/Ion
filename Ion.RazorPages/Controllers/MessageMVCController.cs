using Ion.Server.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class MessageMVCController(MessageController controller) : Controller
    {
        private MessageController controller = controller;

        public IActionResult Index()
        {
            return View();
        }
    }
}
