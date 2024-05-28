using Ion.Server.Controllers;
using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class UserMVCController(UserController controller) : Controller
    {
        private UserController controller = controller;

        [HttpGet]
        public IActionResult Index()
        {
            var result = controller.GetAllUsers().Value;
            return View(result);
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            var actionResult = controller.GetUserById(id);
            var resultType = actionResult.Result.GetType();

            if (resultType == typeof(NotFoundResult))
                return actionResult.Result;

            return View(actionResult.Value);
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
