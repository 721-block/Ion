using Ion.Application.IServices;
using Ion.RazorPages.Extensions;
using Ion.RazorPages.Models;
using Ion.Server.Controllers;
using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.TripRecord;
using Ion.Server.RequestEntities.User;
using MapsterMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class UserMVCController(UserController controller, ITripRecordService tripRecordService, IMapper mapper) : Controller
    {
        private UserController controller = controller;

        [HttpGet]
        public IActionResult Index()
        {
            var result = controller.GetAllUsers().Value;
            return View(result);
        }

        [HttpGet]
        public IActionResult Profile([FromRoute] int id)
        {
            this.AddUserDataInViewBag();
            var actionResult = (ObjectResult)controller.GetUserById(id).Result;
            var resultType = actionResult.GetType();

            if (resultType == typeof(NotFoundResult))
                return actionResult;
            var result = new UserModel();
            result.UserToGet = (UserToGet)actionResult.Value;
            result.TripRecords = tripRecordService.GetByUserId(id).Select(mapper.Map<TripRecordToGet>);

            return View("../UserProfile", result);
        }

        public IActionResult OwnerProfile([FromRoute] int id)
        {
            this.AddUserDataInViewBag();
            var actionResult = (ObjectResult)controller.GetUserById(id).Result;
            var resultType = actionResult.GetType();

            if (resultType == typeof(NotFoundResult))
                return actionResult;
            var result = new UserModel();
            result.UserToGet = (UserToGet)actionResult.Value;
            result.TripRecords = tripRecordService.GetByUserId(id).Select(mapper.Map<TripRecordToGet>);

            return View("../OwnerProfile", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] UserToPost user)
        {
            var actionResult = await controller.CreateUser(user);
            var actionType = actionResult.GetType();

            if (actionType == typeof(NotFoundResult) || actionType == typeof(UnprocessableEntity))
                return actionResult;

            return actionResult;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UserToPatch userToPatch)
        {
            var actionResult = await controller.UpdateUser(id, userToPatch);

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await controller.DeleteUser(id);
            return View();
        }
    }
}
