using Ion.RazorPages.Extensions;
using Ion.Server.Controllers;
using Ion.Server.RequestEntities.Announcement;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class TripRecordMVCController(TripRecordController controller) : Controller
    {
        private TripRecordController controller = controller;

        [HttpGet]
        public IActionResult Index()
        {
            var result = controller.GetAllTripRecords().Value;
            return View(result);
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            var actionResult = controller.GetTripRecordById(id);
            var resultType = actionResult.Result.GetType();

            if (resultType == typeof(NotFoundResult))
                return actionResult.Result;

            return View(actionResult.Value);
        }

        [HttpGet]
        public IActionResult UserTripRecords([FromRoute] int userId)
        {
            var actionResult = controller.GetTripRecordById(userId);
            return View(actionResult.Value);
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await controller.DeleteTripRecord(id);
            return View();
        }
    }
}
