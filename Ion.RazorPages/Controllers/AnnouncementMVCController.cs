using Ion.Server.Controllers;
using Ion.Server.RequestEntities.Announcement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class AnnouncementMVCController(AnnouncementController controller) : Controller
    {
        private AnnouncementController controller = controller;

        [HttpGet]
        public IActionResult Index()
        {
            var result = ((ObjectResult)controller.GetAllAnnouncements().Result).Value;
            return View("../Index", result);
        }

        [HttpGet]
        public IActionResult Details([FromRoute]int id)
        {
            var actionResult = (ObjectResult)controller.GetAnnouncementById(id).Result;
            var resultType = actionResult.GetType();

            if (resultType == typeof(NotFoundResult))
                return actionResult;

            return View(actionResult.Value);
        }

        [HttpGet]
        public IActionResult AuthorAnnouncements([FromRoute]int authorId)
        {
            var actionResult = controller.GetAnnouncementsByAuthorId(authorId);
            return View(actionResult.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]AnnouncementToPost announcement)
        {
            var actionResult = await controller.CreateAnnouncement(announcement);
            var actionType = actionResult.GetType();

            if (actionType == typeof(NotFoundResult) || actionType == typeof(UnprocessableEntity))
                return actionResult;

            return actionResult;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromRoute]int id, [FromForm] AnnouncementToPatch announcementToPatch)
        {
            var actionResult = await controller.UpdateAnnouncement(id, announcementToPatch);

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await controller.DeleteAnnouncement(id);
            return View();
        }
    }
}
