using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Server.RequestEntities.Review;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ion.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController(IReviewService reviewService, IMapper mapper) : Controller
{
    [HttpGet("{reviewId:int}", Name = nameof(GetReviewById))]
    public ActionResult<ReviewToGet> GetReviewById(int reviewId)
    {
        var reviewViewModel = reviewService.GetById(reviewId);
        if (reviewViewModel is null)
            return NotFound();
        var message = mapper.Map<ReviewToGet>(reviewViewModel);
        return Ok(message);
    }
    
    [HttpGet(Name = nameof(GetAllReviews))]
    public ActionResult<IEnumerable<ReviewToGet>> GetAllReviews()
    {
        var reviewViewModels = reviewService.GetAll().Select(mapper.Map<ReviewToGet>);
        return Ok(reviewViewModels);
    }

    [HttpGet("GetByAnnouncementId/{announcementId:int}", Name = nameof(GetByAnnouncementId))]
    public ActionResult<IEnumerable<ReviewToGet>> GetByAnnouncementId(int announcementId)
    {
        var reviews = reviewService.GetByAnnouncementId(announcementId);
        return Ok(reviews.Select(mapper.Map<ReviewToGet>));
    }
    
    [HttpPost(Name = nameof(CreateReview))]
    public async Task<IActionResult> CreateReview([FromBody] ReviewToPost reviewToPost)
    {
        if (reviewToPost is null) 
            return BadRequest("Review is empty");
        if (!ModelState.IsValid)
            return UnprocessableEntity();
        var reviewViewModel = mapper.Map<ReviewViewModel>(reviewToPost);
        var createdReview = await reviewService.AddAsync(reviewViewModel);
        return CreatedAtRoute(nameof(GetReviewById), new {reviewId = createdReview.Id}, createdReview.Id);
    }

    [HttpPatch("{reviewId:int}", Name = nameof(UpdateReview))]
    public async Task<IActionResult> UpdateReview(int reviewId, [FromBody] ReviewToPatch reviewToPatch)
    {
        var reviewViewModel = mapper.Map<ReviewViewModel>(reviewToPatch);
        reviewViewModel.Id = reviewId;
        await reviewService.UpdateAsync(reviewViewModel);
        return Ok();
    }

    [HttpDelete("{reviewId:int}", Name = nameof(DeleteReview))]
    public async Task<IActionResult> DeleteReview(int reviewId)
    {
        await reviewService.DeleteAsync(new ReviewViewModel {Id = reviewId});
        return Ok();
    }
}