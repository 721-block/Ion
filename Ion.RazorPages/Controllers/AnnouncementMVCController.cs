using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.RazorPages.Extensions;
using Ion.RazorPages.Models;
using Ion.Server.Controllers;
using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.Review;
using Ion.Server.RequestEntities.User;
using MapsterMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class AnnouncementMVCController(
        AnnouncementController announcementController,
        IUserService userService,
        IReviewService reviewService,
        ICarService carService,
        IMapper mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var result = new IndexModel();
            var announcements = ((IEnumerable<AnnouncementToGet>)((ObjectResult)announcementController.GetAllAnnouncements().Result).Value).ToList();

            result.Announcements = announcements;
            result.Marks = GetUniqMarks(announcements);
            this.AddUserDataInViewBag();

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
            result.Reviews = reviewService.GetByAnnouncementId(id).Select(mapper.Map<ReviewToGet>).ToList();
            result.Annoncement = announcement;
            result.Author = mapper.Map<UserToGet>(userService.GetById(announcement.AuthorId));
            this.AddUserDataInViewBag();

            return View("../Announce",result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            this.AddUserDataInViewBag();
            return View("../AddAnnounce");
        }

        [HttpPost]
        public IActionResult Index([FromForm]IndexModel model)
        {
            var result = new IndexModel();
            var actionResult = (ObjectResult)announcementController.SearchAnnouncement(model.Parameters).Result;
            var announcements = (IEnumerable<AnnouncementToGet>)actionResult.Value;
            result.Parameters = model.Parameters;
            result.Announcements = announcements;
            result.Marks = GetUniqMarks((IEnumerable<AnnouncementToGet>)((ObjectResult)announcementController.GetAllAnnouncements().Result).Value);
            this.AddUserDataInViewBag();
            return View("../Index", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]AddAnnounceModel announce)
        {
            var addedCar = await carService.AddAsync(mapper.Map<CarViewModel>(announce.Car));
            var announcement = announce.Announcement;
            announcement.CarId = addedCar.Id;
            var actionResult = await announcementController.CreateAnnouncement(announce.Announcement);
            var actionType = actionResult.GetType();

            if (actionType == typeof(NotFoundResult) || actionType == typeof(UnprocessableEntity))
                return actionResult;
            var objectResult = (ObjectResult)actionResult;

            return RedirectToAction(nameof(Details), new {id = objectResult.Value });
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

        private IEnumerable<string> GetUniqMarks(IEnumerable<AnnouncementToGet> announcements)
        {
            return announcements.Select(x => x.CarName).Distinct();
        }
    }
}
