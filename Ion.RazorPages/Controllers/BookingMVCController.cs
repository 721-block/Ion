using Ion.Server.Controllers;
using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.Bookings;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class BookingMVCController(BookingController controller) : Controller
    {
        private BookingController controller = controller;

        public IActionResult Index()
        {
            var result = controller.GetAllBookings().Value;

            return View(result);
        }

        public IActionResult Details([FromRoute] int id)
        {
            var actionResult = controller.GetBookingById(id);
            var resultType = actionResult.Result.GetType();

            if (resultType == typeof(NotFoundResult))
                return actionResult.Result;

            return View(actionResult.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]BookingToPost booking)
        {
            var actionResult = await controller.CreateBooking(booking);
            var actionType = actionResult.GetType();

            if (actionType == typeof(NotFoundResult) || actionType == typeof(UnprocessableEntity))
                return actionResult;

            return actionResult;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] BookingToPatch bookingToPatch)
        {
            var actionResult = await controller.UpdateBooking(id, bookingToPatch);

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await controller.DeleteBooking(id);
            return View();
        }
    }
}
