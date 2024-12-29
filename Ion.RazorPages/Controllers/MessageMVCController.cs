using Ion.Server.Controllers;
using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.Message;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class MessageMVCController(MessageController controller) : Controller
    {
        private MessageController controller = controller;

        [HttpGet]
        public IActionResult Index()
        {
            var result = controller.GetAllMessages().Value;
            return View(result);
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            var actionResult = controller.GetMessageById(id);
            var resultType = actionResult.Result!.GetType();

            if (resultType == typeof(NotFoundResult))
                return actionResult.Result;

            return View(actionResult.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] MessageToPost message)
        {
            var actionResult = await controller.CreateMessage(message);
            var actionType = actionResult.GetType();

            if (actionType == typeof(NotFoundResult) || actionType == typeof(UnprocessableEntity))
                return actionResult;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] MessageToPatch messageToPatch)
        {
            var actionResult = await controller.UpdateMessage(id, messageToPatch);

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await controller.DeleteMessage(id);

            return View();
        }
    }
}
