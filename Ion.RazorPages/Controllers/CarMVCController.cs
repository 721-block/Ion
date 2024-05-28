using Ion.Server.Controllers;
using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.Car;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class CarMVCController(CarController controller) : Controller
    {
        private CarController controller = controller;

        [HttpGet]
        public IActionResult Index()
        {
            var result = controller.GetAllCars().Value;
            return View(result);
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            var actionResult = controller.GetCarById(id);
            var resultType = actionResult.Result.GetType();

            if (resultType == typeof(NotFoundResult))
                return actionResult.Result;

            return View(actionResult.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CarToPost carToPost)
        {
            var actionResult = await controller.CreateCar(carToPost);
            var actionType = actionResult.GetType();

            if (actionType == typeof(NotFoundResult) || actionType == typeof(UnprocessableEntity))
                return actionResult;

            return actionResult;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] CarToPatch carToPatch)
        {
            var actionResult = await controller.UpdateCar(id, carToPatch);

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await controller.DeleteCar(id);
            return View();
        }
    }
}
