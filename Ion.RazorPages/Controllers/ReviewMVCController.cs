using Ion.Server.Controllers;
using Ion.Server.RequestEntities.Announcement;
using Ion.Server.RequestEntities.Review;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Controllers
{
    public class ReviewMVCController(ReviewController controller) : Controller
    {
        private ReviewController controller = controller;

        [HttpGet]
        public IActionResult Index()
        {
            var result = controller.GetAllReviews().Value;
            return View(result);
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            var actionResult = controller.GetReviewById(id);
            var resultType = actionResult.Result.GetType();

            if (resultType == typeof(NotFoundResult))
                return actionResult.Result;

            return View(actionResult.Value);
        }

        [HttpGet]
        public IActionResult AnnouncementReviews([FromRoute] int announcementId)
        {
            var actionResult = controller.GetByAnnouncementId(announcementId);
            return View(actionResult.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ReviewToPost review)
        {
            var actionResult = await controller.CreateReview(review);
            var actionType = actionResult.GetType();

            if (actionType == typeof(NotFoundResult) || actionType == typeof(UnprocessableEntity))
                return actionResult;

            return actionResult;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] ReviewToPatch reviewToPatch)
        {
            var actionResult = await controller.UpdateReview(id, reviewToPatch);

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await controller.DeleteReview(id);
            return View();
        }
    }
}
