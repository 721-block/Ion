using Ion.Application.Base;
using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Server.RequestEntities.Announcement;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ion.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnnouncementController(IAnnouncementService announcementService, IUserImageService imageService, IMapper mapper, IWebHostEnvironment appEnvironment) : Controller
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
        var announcements = announcementService.GetAll().Select(mapper.Map<AnnouncementToGet>);
        
        return Ok(announcements);
    }
    
    [HttpGet("GetAnnouncementsByAuthorId/{authorId:int}", Name = nameof(GetAnnouncementsByAuthorId))]
    public ActionResult<IEnumerable<AnnouncementToGet>> GetAnnouncementsByAuthorId(int authorId)
    {
        var announcements = announcementService.GetByAuthorId(authorId);
        var result = announcements.Select(mapper.Map<AnnouncementToGet>);
        
        return Ok(result);
    }

    [HttpGet("Search", Name = nameof(SearchAnnouncement))]
    public ActionResult<IEnumerable<AnnouncementToGet>> SearchAnnouncement([FromQuery] FilterParameters parameters)
    {
        var announcements = announcementService.GetWithFilters(parameters);
        var result = announcements.Select(mapper.Map<AnnouncementToGet>);
        
        return Ok(result);
    }

    [HttpPost(Name = nameof(CreateAnnouncement))]
    public async Task<IActionResult> CreateAnnouncement([FromBody] AnnouncementToPost announcementToPost)
    {
        if (announcementToPost is null) 
            return BadRequest("Announcement is empty");
        if (!ModelState.IsValid)
            return UnprocessableEntity();
        
        var imagePath = imageService.UploadImages(announcementToPost.Files, announcementToPost.AuthorId, announcementToPost.CarId);
        var announcementViewModel = mapper.Map<AnnouncementViewModel>(announcementToPost);
        announcementViewModel.PathToImages = imagePath;
        var createdAnnouncement = await announcementService.AddAsync(announcementViewModel);
        
        return CreatedAtRoute(nameof(GetAnnouncementById), new {announcementId = createdAnnouncement.Id}, createdAnnouncement.Id);
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

    [HttpPost("uploadImage")]
    public async Task<IActionResult> UploadImage(string imageName, IFormFile uploadedFile)
    {
        if (uploadedFile != null)
        {
            // путь к папке Files
            string path = $"/images/1/{imageName}.png";
            // сохраняем файл в папку Files в каталоге wwwroot
            using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
        }

        return Ok();
    }
}