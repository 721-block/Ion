using Ion.Application.IServices;
using Ion.Domain.Entities;
using Ion.RazorPages.Models;
using Ion.Server.Controllers;
using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.Review;
using Ion.Server.RequestEntities.User;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class AnnouncementMVCController(
        AnnouncementController announcementController, 
        IUserService userService,
        IReviewService reviewService,
        IMapper mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var result = new IndexModel();
            var announcements = ((IEnumerable<AnnouncementToGet>)((ObjectResult)announcementController.GetAllAnnouncements().Result).Value).ToList();

            result.Announcements = announcements;
            result.Marks = announcements.Select(x => x.CarName).Distinct();

            return View("../Index", result);
        }

        [HttpGet]
        public IActionResult Details([FromRoute]int id)
        {
            var result = new AnnounceModel();

            var announcementResult = (ObjectResult)announcementController.GetAnnouncementById(id).Result;
            var resultType = announcementResult.GetType();

            if (resultType == typeof(NotFoundResult))
                return announcementResult;

            var announcement = (AnnouncementToGet)announcementResult.Value;
            result.Reviews = reviewService.GetByAnnouncementId(id).Select(mapper.Map<ReviewToGet>);
            result.Annoncement = announcement;
            result.Author = mapper.Map<UserToGet>(userService.GetById(announcement.Id));

            return View(result);
        }

        [HttpGet]
        public IActionResult AuthorAnnouncements([FromRoute]int authorId)
        {
            var actionResult = announcementController.GetAnnouncementsByAuthorId(authorId);
            return View(actionResult.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]AnnouncementToPost announcement)
        {
            var actionResult = await announcementController.CreateAnnouncement(announcement);
            var actionType = actionResult.GetType();

            if (actionType == typeof(NotFoundResult) || actionType == typeof(UnprocessableEntity))
                return actionResult;

            return actionResult;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromRoute]int id, [FromForm] AnnouncementToPatch announcementToPatch)
        {
            var actionResult = await announcementController.UpdateAnnouncement(id, announcementToPatch);

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await announcementController.DeleteAnnouncement(id);
            return View();
        }
    }
}
