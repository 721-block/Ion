using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Server.RequestEntities.Announcement;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ion.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementController(IAnnouncementService announcementService, IMapper mapper) : Controller
{
    [HttpGet("{announcementId:int}", Name = nameof(GetAnnouncementById))]
    public ActionResult<AnnouncementToGet> GetAnnouncementById(int announcementId)
    {
        var announcementViewModel = announcementService.GetById(announcementId);
        if (announcementViewModel is null)
            return NotFound();
        var announcementToGet = mapper.Map<AnnouncementToGet>(announcementViewModel);
        return Ok(announcementToGet);
    }
    
    [HttpGet(Name = nameof(GetAllAnnouncements))]
    public ActionResult<IEnumerable<AnnouncementToGet>> GetAllAnnouncements()
    {
        var announcements = announcementService.GetAll();
        return Ok(announcements);
    }
    
    [HttpGet("GetAnnouncementsByAuthorId/{authorId:int}", Name = nameof(GetAnnouncementsByAuthorId))]
    public ActionResult<IEnumerable<AnnouncementToGet>> GetAnnouncementsByAuthorId(int authorId)
    {
        var announcements = announcementService.GetByAuthorId(authorId);
        var result = announcements.Select(mapper.Map<AnnouncementToGet>).ToList();
        return Ok(result);
    }

    [HttpPost(Name = nameof(CreateAnnouncement))]
    public async Task<IActionResult> CreateAnnouncement([FromBody] AnnouncementToPost announcementToPost)
    {
        if (announcementToPost is null) 
            return BadRequest("Announcement is empty");
        if (!ModelState.IsValid)
            return UnprocessableEntity();
        var announcementViewModel = mapper.Map<AnnouncementViewModel>(announcementToPost);
        var createdAnnouncement = await announcementService.AddAsync(announcementViewModel);
        return CreatedAtRoute(nameof(GetAnnouncementById), new {userId = createdAnnouncement.Id}, createdAnnouncement.Id);
    }

    [HttpPatch("{announcementId:int}", Name = nameof(UpdateAnnouncement))]
    public async Task<IActionResult> UpdateAnnouncement(int announcementId, [FromBody] AnnouncementToPatch announcementToPatch)
    {
        var announcementViewModel = mapper.Map<AnnouncementViewModel>(announcementToPatch);
        announcementViewModel.Id = announcementId;
        await announcementService.UpdateAsync(announcementViewModel);
        return Ok();
    }

    [HttpDelete("{announcementId:int}", Name = nameof(DeleteAnnouncement))]
    public async Task<IActionResult> DeleteAnnouncement(int announcementId)
    {
        await announcementService.DeleteAsync(new AnnouncementViewModel {Id = announcementId});
        return Ok();
    }
}